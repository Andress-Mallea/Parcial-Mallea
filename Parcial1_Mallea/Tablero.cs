public class Tableros{
    public string[] Tablero = {"[]","[]","[]","[]","[]","[]","[]","[]","[]"};
    public int ExtraTamano = 0;
     public void MostarTablero(){
            int SaltoLinea=0;
            string Bordes = "==============================";
            for(int i = 0; i < ExtraTamano; i++){
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
}
