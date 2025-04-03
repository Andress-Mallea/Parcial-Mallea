using System.Diagnostics;

public class TressEnRalla{
        public string[] Tablero ={"[]","[]","[]","[]","[]","[]","[]","[]","[]"};
        public string CaracterJugador;
        public string CaracterCompu;
        public int Orden;
        public int TamanoExtraBordes = 0;
        
        public void JugarDeNuevo(){
            string[] nuevo_tablero = {"[]","[]","[]","[]","[]","[]","[]","[]","[]"};
            Tablero = nuevo_tablero;
            InicciarJuego();
        }
        public void ElegirCaracter(){
            Console.WriteLine("==============================================");
            Console.WriteLine(@"Eliga con que Caracter Quiere Jugar
1. X
2. O
3. Cancelar");
            switch(PedirOpcion()){
                case 1:
                Console.WriteLine("Caracter Selecionado: X");
                Console.WriteLine("==============================================");
                CaracterJugador = "X";
                CaracterCompu = "O";
                Orden = 1;
                string Espera = Console.ReadLine();
                Console.Clear();
                break;
                case 2:
                Console.WriteLine("Caracter Selecionado: O");
                Console.WriteLine("==============================================");
                CaracterJugador = "X";
                CaracterCompu = "O";
                Orden = 2;
                Espera = Console.ReadLine();
                Console.Clear();
                break;
                case 3:
                Espera = Console.ReadLine();
                Console.Clear();
                break;
                default:
                Console.WriteLine("Error: Opcion invalida");
                Console.WriteLine("==============================================");
                Espera = Console.ReadLine();
                Console.Clear();
                ElegirCaracter();
                break;
            }
        }
        public int PedirOpcion(){
            Console.WriteLine("Introduzca Que Opcion Quiere Hacer: ");
            string Opcion = Console.ReadLine();
            if(Opcion.Length == 1){
                if(Opcion[0] >= 49 && Opcion[0] <= 57 ){
                    int Result = Convert.ToInt32(Opcion);
                    return Result;
                }
                else{
                Console.WriteLine("Error: Opcion No Valida");
                return PedirOpcion();
                }
            }
            else{
                Console.WriteLine("Error: Opcion No Valida");
                return PedirOpcion();
            }
        }
        public void MostarTablero(){
            int SaltoLinea=0;
            string Bordes = "==============================";
            for(int i = 0; i < TamanoExtraBordes; i++){
                Bordes += "=";
            }
            Console.WriteLine(Bordes);
            for(int i =0; i <Tablero.Length; i++){
                if(SaltoLinea == 3){
                    Console.WriteLine("");
                    SaltoLinea = 0;
                }
                Console.Write($"| {i+1}. " + Tablero[i]+"  |");
                SaltoLinea ++;
            }
            Console.WriteLine("");
            Console.WriteLine(Bordes);
        }
        public void IA_Basica(){
            int[] PosicionesPosibles = {0,1,2,3,4,5,6,7,8};
            Random rand = new Random();
            int PosicionRandom = PosicionesPosibles[rand.Next(8)];
            bool Coloco = false;
            while(Coloco == false){
                if(Tablero.Contains("[]")){
                    if(Tablero[PosicionRandom] == "[]"){
                        Tablero[PosicionRandom] = $"[{CaracterCompu}]";
                        TamanoExtraBordes ++;
                        break;
                    }
                    else{
                        PosicionRandom = PosicionesPosibles[rand.Next(8)];
                    }
                }
                else{
                    break;
                }
            }
        }
        public void MenuJuego(){
            Console.WriteLine("==============================================");
            Console.WriteLine(@"Bienvenido  A Tres En Raya que Quiere Hacer
1. Empezar El Juego
2. Salir");
            switch(PedirOpcion()){
                case 1:
                InicciarJuego();
                Console.Clear();
                break;
                case 2:
                Console.Clear();
                break;
                default:
                Console.WriteLine("Error: Opcion invalida");
                Console.WriteLine("==============================================");
                ElegirCaracter();
                string Espera = Console.ReadLine();
                Console.Clear();
                MenuJuego();
                break;
            }
        }
        public void InicciarJuego(){
            Console.WriteLine("==============================================================");
            Console.WriteLine(@"||Bienvenido a Tres En Ralla Para jugar               ||
||Introduce el numero a lado izquierdo de               || 
||la casilla donde quieras insertar tu movimineto               ||
==================================================================");
            ElegirCaracter();
            while(Tablero.Contains("[]")){
                MostarTablero();
                if(Orden == 1){
                    EleccionJugador();
                    Orden =2;
                }
                else{
                    IA_Basica();
                    Orden =1;
                }
                if(Tablero.Contains("[]") != true){
                    Victoria();
                    break;
                }
                string Espera = Console.ReadLine();
                Console.Clear();
            }

        }
        public void EleccionJugador(){
            int Lugar = PedirOpcion()-1;
             bool Coloco = false;
                while(Coloco == false){
                if(Tablero.Contains("[]")){
                    if(Tablero[Lugar] == "[]"){
                        Tablero[Lugar] = $"[{CaracterJugador}]";
                        TamanoExtraBordes ++;
                        break;
                    }
                    else{
                        Console.WriteLine("Error: Opcion No Valida");
                        Lugar = PedirOpcion()-1;
                    }
                }
                else{

                    break;
                }
            }
        }
        public void Victoria(){
            bool Victoria = false;
            int i = 0;
            string[] Caracteres = {"[O]","[X]"};
            while(Victoria != true){
                string Caracter = Caracteres[i];
                if(Tablero[0] == Caracter && Tablero[1] == Caracter&& Tablero[2] == Caracter){
                    Console.WriteLine("==============================================");
                    Console.WriteLine($"Gano El: {Caracter}");
                    Console.WriteLine("Quiere jugar de nuevo");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    switch(PedirOpcion()){
                        case 1:
                        JugarDeNuevo();
                        break;
                        case 2:
                        break;
                        default:
                        Console.WriteLine("Error: Opcion invalida");
                        Console.WriteLine("==============================================");
                        string Espera = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    break;
                }
                else if(Tablero[6] == Caracter && Tablero[7] == Caracter&& Tablero[8] == Caracter){
                    Console.WriteLine("==============================================");
                    Console.WriteLine($"Gano El: {Caracter}");
                    Console.WriteLine("Quiere jugar de nuevo");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    switch(PedirOpcion()){
                        case 1:
                        JugarDeNuevo();
                        break;
                        case 2:
                        break;
                        default:
                        Console.WriteLine("Error: Opcion invalida");
                        Console.WriteLine("==============================================");
                        string Espera = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
                else if(Tablero[0] == Caracter && Tablero[3] == Caracter&& Tablero[6] == Caracter){
                    Console.WriteLine("==============================================");
                    Console.WriteLine($"Gano El: {Caracter}");
                    Console.WriteLine("Quiere jugar de nuevo");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    switch(PedirOpcion()){
                        case 1:
                        JugarDeNuevo();
                        break;
                        case 2:
                        break;
                        default:
                        Console.WriteLine("Error: Opcion invalida");
                        Console.WriteLine("==============================================");
                        string Espera = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
                else if(Tablero[2] == Caracter && Tablero[5] == Caracter&& Tablero[8] == Caracter){
                    Console.WriteLine("==============================================");
                    Console.WriteLine($"Gano El: {Caracter}");
                    Console.WriteLine("Quiere jugar de nuevo");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    switch(PedirOpcion()){
                        case 1:
                        JugarDeNuevo();
                        break;
                        case 2:
                        break;
                        default:
                        Console.WriteLine("Error: Opcion invalida");
                        Console.WriteLine("==============================================");
                        string Espera = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
                else if(Tablero[0] == Caracter && Tablero[4] == Caracter&& Tablero[8] == Caracter){
                    Console.WriteLine("==============================================");
                    Console.WriteLine($"Gano El: {Caracter}");
                    Console.WriteLine("Quiere jugar de nuevo");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    switch(PedirOpcion()){
                        case 1:
                        JugarDeNuevo();
                        break;
                        case 2:
                        break;
                        default:
                        Console.WriteLine("Error: Opcion invalida");
                        Console.WriteLine("==============================================");
                        string Espera = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
                else if(Tablero[2] == Caracter && Tablero[4] == Caracter&& Tablero[6] == Caracter){
                    Console.WriteLine("==============================================");
                    Console.WriteLine($"Gano El: {Caracter}");
                    Console.WriteLine("Quiere jugar de nuevo");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    switch(PedirOpcion()){
                        case 1:
                        JugarDeNuevo();
                        break;
                        case 2:
                        break;
                        default:
                        Console.WriteLine("Error: Opcion invalida");
                        Console.WriteLine("==============================================");
                        string Espera = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
                i ++;
                if(i == 2){
                    Console.WriteLine("==============================================");
                    Console.WriteLine($"Empate");
                    Console.WriteLine("Quiere jugar de nuevo");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    switch(PedirOpcion()){
                        case 1:
                        JugarDeNuevo();
                        break;
                        case 2:
                        break;
                        default:
                        Console.WriteLine("Error: Opcion invalida");
                        Console.WriteLine("==============================================");
                        string Espera = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    break;
                }
            }
        }
}
