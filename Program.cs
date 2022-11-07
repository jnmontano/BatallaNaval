using System;
class Juego
{
    static int jugador = 17;
    static int enemigo = 17;
    static string turno = "jugador";
    static char[] filas = new char[10] {'A','B','C','D','E','F','G','H','I','J'};
    static int[] columnas = new int[10] {0,1,2,3,4,5,6,7,8,9};
    static char[,] tablero_jugador = new char[10,10];
    static char[,] tablero_enemigo = new char[10,10];
    static bool juegoTerminado = false;
    static bool listoJugador = false;
    static bool listoEnemigo = false;
    static bool[] barcosJugador = new bool[5] { false, false, false, false, false };//indicador de los barcos creados
    static bool[] barcosEnemigo = new bool[5] { false, false, false, false, false };//indicador de los barcos creados 
    static char cordX = '0';
    static int cordY = 0;
    static void Main(){
        IniciarMatriz();
       do //creando barcos de Jugador
        {
            Console.Clear();
            TableroJugador();
            tipoBarcos();
            if (barcosJugador[0] && barcosJugador[1] && barcosJugador[2] && barcosJugador[3] && barcosJugador[4])
            {
                listoJugador = true;
                Console.Clear();
                TableroJugador();
            }
        } while (!listoJugador);

        do //creando barcos de Enemigo
        {
            Console.Clear();
            TableroEnemigo();
            tipoBarcosEnemigo();
            if (barcosEnemigo[0] && barcosEnemigo[1] && barcosEnemigo[2] && barcosEnemigo[3] && barcosEnemigo[4])
            {
                Console.Clear();
                listoEnemigo = true;
                TableroEnemigo();
            }
        } while (!listoEnemigo);

        //Funcion JugarTurnos intercala entre los dos jugadores
        do
        {
            if(turno=="jugador")
            {
                try
                {
                    JugarTurnos(turno);
                    turno = "enemigo";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("    ┌─────────────────────────────────────────────────┐");
                    Console.WriteLine("    │    PARAMETRO INGRESADO INCORRECTO !!!!!!!!!     │");
                    Console.WriteLine("    └─────────────────────────────────────────────────┘");
                    Thread.Sleep(3000);
                }
            }
                
            if(turno=="enemigo")
            {
                try
                {
                    JugarTurnos(turno);
                    turno = "jugador";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("    ┌─────────────────────────────────────────────────┐");
                    Console.WriteLine("    │    PARAMETRO INGRESADO INCORRECTO !!!!!!!!!     │");
                    Console.WriteLine("    └─────────────────────────────────────────────────┘");
                    Thread.Sleep(3000);
                }                
            }
                
        } while(true);        
    }

    /*
     *  Esta funcion para intercalar los turnos, la variable turno
     *  intercala los valores de "jugador" y "enemigo"
     */
    private static void JugarTurnos(String turno)
    {
        if (turno == "jugador")
        {
            Console.Clear();
            TableroJugador();
            //tablero_enemigo[1,1] = '5';
            Console.WriteLine();
            Console.WriteLine("                TABLERO DISPAROS");
            Console.WriteLine("       1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine("     ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            for (int f = 0; f < filas.Length; f++)
            {
                Console.Write("   " + filas[f] + " │");
                for (int c = 0; c < columnas.Length; c++)
                {
                    if (c != 10)
                    {
                        if (tablero_enemigo[f, c] == 'O' || tablero_enemigo[f, c] == 'X')
                            Console.Write(" " + tablero_enemigo[f, c] + " │");
                        else
                            Console.Write("   │");
                    }
                }
                Console.WriteLine();
                if (f != 9)
                    Console.WriteLine("     ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤  ");
            }
            Console.WriteLine("     └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
            Console.WriteLine("     DISPARAR TURNO JUGADOR");
            Console.Write("     Fila =>");
            cordX = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.Write("     Columna =>");
            cordY = Convert.ToInt32(Console.ReadLine());
            if (tablero_enemigo[valor(cordX), (cordY - 1)] == ' ')
                tablero_enemigo[valor(cordX), (cordY - 1)] = 'O';
            else
                if (tablero_enemigo[valor(cordX), (cordY - 1)] != ' ' || tablero_enemigo[valor(cordX), (cordY - 1)] != 'O')//Verificamos que la posicion del
            {                                                                                                              //disparo sea un navio
                tablero_enemigo[valor(cordX), (cordY - 1)] = 'X';
                jugador--;
            }
                

        }
        if (turno == "enemigo")
        {
            Console.Clear();
            TableroEnemigo();
            Console.WriteLine();
            Console.WriteLine("                TABLERO DISPAROS");
            Console.WriteLine("       1   2   3   4   5   6   7   8   9   10");
            Console.WriteLine("     ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            for (int f = 0; f < filas.Length; f++)
            {
                Console.Write("   " + filas[f] + " │");
                for (int c = 0; c < columnas.Length; c++)
                {
                    if (c != 10)
                    {
                        if (tablero_jugador[f, c] == 'O' || tablero_jugador[f, c] == 'X')
                            Console.Write(" " + tablero_jugador[f, c] + " │");
                        else
                            Console.Write("   │");
                    }
                }
                Console.WriteLine();
                if (f != 9)
                    Console.WriteLine("     ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤  ");
            }
            Console.WriteLine("     └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
            Console.WriteLine("     DISPARAR TURNO ENEMIGO");
            Console.Write("     Fila =>");
            cordX = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.Write("     Columna =>");
            cordY = Convert.ToInt32(Console.ReadLine());
            if (tablero_jugador[valor(cordX), (cordY - 1)] == ' ')
                tablero_jugador[valor(cordX), (cordY - 1)] = 'O';
            else
                if (tablero_jugador[valor(cordX), (cordY - 1)] != ' ' || tablero_jugador[valor(cordX), (cordY - 1)] != 'O')//Verificamos que la posicion del
            {                                                                                                              //disparo sea un navio
                tablero_jugador[valor(cordX), (cordY - 1)] = 'X';
                enemigo--;
            }                    
        }
    }

    /*
     *  Funcion para inicializar la Matriz con espacios
     */
    private static void IniciarMatriz()
    {
        for (int f = 0; f < filas.Length; f++)
        {
            for (int c = 0; c < columnas.Length; c++)
            {
                tablero_jugador[f, c] = ' ';
                tablero_enemigo[f, c] = ' ';
            }
        }
    }

    /*
     *  Funcion para dibujar el Tablero de "jugador"
     */
    private static void TableroJugador(){
        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine("                TABLERO JUGADOR");
        Console.WriteLine("       1   2   3   4   5   6   7   8   9   10");
        Console.WriteLine("     ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
        for (int f=0; f<filas.Length; f++){
            Console.Write("   "+filas[f]+" │");
            for(int c=0;c<columnas.Length;c++){
                if (c != 10)
                {
                    Console.Write(" " + tablero_jugador[f, c] + " │");
                }                    
            }
            Console.WriteLine();
            if(f!=9)
            Console.WriteLine("     ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤  ");
        }
        Console.WriteLine("     └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
    }

    /*
     *  Funcion para dibujar el Tablero de "enemigo"
     */
    private static void TableroEnemigo()
    {
        //Console.Clear();
        Console.WriteLine();
        Console.WriteLine("                TABLERO ENEMIGO");
        Console.WriteLine("       1   2   3   4   5   6   7   8   9   10");
        Console.WriteLine("     ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
        for (int f = 0; f < filas.Length; f++)
        {
            Console.Write("   " + filas[f] + " │");
            for (int c = 0; c < columnas.Length; c++)
            {
                if (c != 10)
                {
                    Console.Write(" " + tablero_enemigo[f, c] + " │");
                }
            }
            Console.WriteLine();
            if (f != 9)
                Console.WriteLine("     ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤  ");
        }
        Console.WriteLine("     └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
    }


    /*
     *  Funcion que posiciona las diferentes enbarcaciones colocandolos
     *  de izquierda a derecha en posicion horizontal
     */
    private static void colocarBarcos(int op)
    {
        /*
        PortaAviones estara representado por '55555'
        Acorazado  estara representado por '4444'
        Crucero estara representado por '333'
        SubMarino estara representado por '222'
        Destructor estara representado por '11'
        */

        switch (op)
        {
            case 5:
                if (barcosJugador[op - 1] == false)
                {
                    Console.WriteLine("Colocar Porta Aviones 55555");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 6)
                    {
                        if (tablero_jugador[valor(cordX), (cordY - 1)] == ' ' && tablero_jugador[valor(cordX), (cordY)] == ' ' && tablero_jugador[valor(cordX), (cordY + 1)] == ' '
                            && tablero_jugador[valor(cordX), (cordY + 2)] == ' ' && tablero_jugador[valor(cordX), (cordY + 3)] == ' ')
                        {
                            tablero_jugador[valor(cordX), (cordY - 1)] = '5'; //marcamos con 5 los portaaviones
                            tablero_jugador[valor(cordX), (cordY)] = '5';
                            tablero_jugador[valor(cordX), (cordY + 1)] = '5';
                            tablero_jugador[valor(cordX), (cordY + 2)] = '5';
                            tablero_jugador[valor(cordX), (cordY + 3)] = '5';
                            barcosJugador[op - 1] = true;
                        }
                    }
                }
                break;
            case 4:
                if (barcosJugador[op - 1] == false)
                {
                    Console.WriteLine("Colocar Acorazado 4444");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 7)
                    {
                        if (tablero_jugador[valor(cordX), (cordY - 1)] == ' ' && tablero_jugador[valor(cordX), (cordY)] == ' '
                            && tablero_jugador[valor(cordX), (cordY + 1)] == ' ' && tablero_jugador[valor(cordX), (cordY + 2)] == ' ')
                        {
                            tablero_jugador[valor(cordX), (cordY - 1)] = '4'; //marcamos con 4 los acorazados
                            tablero_jugador[valor(cordX), (cordY)] = '4';
                            tablero_jugador[valor(cordX), (cordY + 1)] = '4';
                            tablero_jugador[valor(cordX), (cordY + 2)] = '4';
                            barcosJugador[op - 1] = true;
                        }
                    }
                }
                break;
            case 3:
                if (barcosJugador[op - 1] == false)
                {
                    Console.WriteLine("Colocar Crucero 333");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 8)
                    {
                        if (tablero_jugador[valor(cordX), (cordY - 1)] == ' ' && tablero_jugador[valor(cordX), (cordY)] == ' ' && tablero_jugador[valor(cordX), (cordY + 1)] == ' ')
                        {
                            tablero_jugador[valor(cordX), (cordY - 1)] = '3'; //marcamos con 3 los cruceros
                            tablero_jugador[valor(cordX), (cordY)] = '3';
                            tablero_jugador[valor(cordX), (cordY + 1)] = '3';
                            barcosJugador[op - 1] = true;
                        }
                    }
                }
                break;
            case 2:
                if (barcosJugador[op - 1] == false)
                {
                    Console.WriteLine("Colocar Submarino 222");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 8)
                    {
                        if (tablero_jugador[valor(cordX), (cordY - 1)] == ' ' && tablero_jugador[valor(cordX), (cordY)] == ' ' && tablero_jugador[valor(cordX), (cordY + 1)] == ' ')
                        {
                            tablero_jugador[valor(cordX), (cordY - 1)] = '2'; //marcamos con 2 los Submarino
                            tablero_jugador[valor(cordX), (cordY)] = '2';
                            tablero_jugador[valor(cordX), (cordY + 1)] = '2';
                            barcosJugador[op - 1] = true;
                        }
                    }
                }
                break;
            case 1:
                if (barcosJugador[op - 1] == false)
                {
                    Console.WriteLine("Colocar Destructor 11");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 8)
                    {
                        if (tablero_jugador[valor(cordX), (cordY - 1)] == ' ' && tablero_jugador[valor(cordX), (cordY)] == ' ')
                        {
                            tablero_jugador[valor(cordX), (cordY - 1)] = '1'; //marcamos con 1 los destructores
                            tablero_jugador[valor(cordX), (cordY)] = '1';
                            barcosJugador[op - 1] = true;
                        }
                    }
                }
                break;
        }
    }
    /*
    *  Funcion que posiciona las diferentes enbarcaciones colocandolos
    *  de izquierda a derecha en posicion horizontal para el enemigo
    */
    private static void colocarBarcosEnemigo(int op)
    {
        /*
        PortaAviones estara representado por '55555' en el mapa
        Acorazado  estara representado por '4444' en el mapa
        Crucero estara representado por '333' en el mapa
        SubMarino estara representado por '222' en el mapa
        Destructor estara representado por '11' en el mapa
        */

        switch (op)
        {
            case 5:
                if (barcosEnemigo[op - 1] == false)
                {
                    Console.WriteLine("Colocar Porta Aviones 55555");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 6)
                    {
                        if (tablero_enemigo[valor(cordX), (cordY - 1)] == ' ' && tablero_enemigo[valor(cordX), (cordY)] == ' ' && tablero_enemigo[valor(cordX), (cordY + 1)] == ' '
                            && tablero_enemigo[valor(cordX), (cordY + 2)] == ' ' && tablero_enemigo[valor(cordX), (cordY + 3)] == ' ')
                        {
                            tablero_enemigo[valor(cordX), (cordY - 1)] = '5'; //marcamos con 5 los portaaviones
                            tablero_enemigo[valor(cordX), (cordY)] = '5';
                            tablero_enemigo[valor(cordX), (cordY + 1)] = '5';
                            tablero_enemigo[valor(cordX), (cordY + 2)] = '5';
                            tablero_enemigo[valor(cordX), (cordY + 3)] = '5';
                            barcosEnemigo[op - 1] = true;
                        }
                    }
                }
                break;
            case 4:
                if (barcosEnemigo[op - 1] == false)
                {
                    Console.WriteLine("Colocar Acorazado 4444");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 7)
                    {
                        if (tablero_enemigo[valor(cordX), (cordY - 1)] == ' ' && tablero_enemigo[valor(cordX), (cordY)] == ' '
                            && tablero_enemigo[valor(cordX), (cordY + 1)] == ' ' && tablero_enemigo[valor(cordX), (cordY + 2)] == ' ')
                        {
                            tablero_enemigo[valor(cordX), (cordY - 1)] = '4'; //marcamos con 4 los acorazados
                            tablero_enemigo[valor(cordX), (cordY)] = '4';
                            tablero_enemigo[valor(cordX), (cordY + 1)] = '4';
                            tablero_enemigo[valor(cordX), (cordY + 2)] = '4';
                            barcosEnemigo[op - 1] = true;
                        }
                    }
                }
                break;
            case 3:
                if (barcosEnemigo[op - 1] == false)
                {
                    Console.WriteLine("Colocar Crucero 333");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 8)
                    {
                        if (tablero_enemigo[valor(cordX), (cordY - 1)] == ' ' && tablero_enemigo[valor(cordX), (cordY)] == ' ' && tablero_enemigo[valor(cordX), (cordY + 1)] == ' ')
                        {
                            tablero_enemigo[valor(cordX), (cordY - 1)] = '3'; //marcamos con 3 los cruceros
                            tablero_enemigo[valor(cordX), (cordY)] = '3';
                            tablero_enemigo[valor(cordX), (cordY + 1)] = '3';
                            barcosEnemigo[op - 1] = true;
                        }
                    }
                }
                break;
            case 2:
                if (barcosEnemigo[op - 1] == false)
                {
                    Console.WriteLine("Colocar Submarino 222");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 8)
                    {
                        if (tablero_enemigo[valor(cordX), (cordY - 1)] == ' ' && tablero_enemigo[valor(cordX), (cordY)] == ' ' && tablero_enemigo[valor(cordX), (cordY + 1)] == ' ')
                        {
                            tablero_enemigo[valor(cordX), (cordY - 1)] = '2'; //marcamos con 2 los Submarino
                            tablero_enemigo[valor(cordX), (cordY)] = '2';
                            tablero_enemigo[valor(cordX), (cordY + 1)] = '2';
                            barcosEnemigo[op - 1] = true;
                        }
                    }
                }
                break;
            case 1:
                if (barcosEnemigo[op - 1] == false)
                {
                    Console.WriteLine("Colocar Destructor 11");
                    Console.Write("Fila =>");
                    cordX = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.Write("Columna =>");
                    cordY = Convert.ToInt32(Console.ReadLine());
                    if (cordY >= 1 && cordY <= 8)
                    {
                        if (tablero_enemigo[valor(cordX), (cordY - 1)] == ' ' && tablero_enemigo[valor(cordX), (cordY)] == ' ')
                        {
                            tablero_enemigo[valor(cordX), (cordY - 1)] = '1'; //marcamos con 1 los destructores
                            tablero_enemigo[valor(cordX), (cordY)] = '1';
                            barcosEnemigo[op - 1] = true;
                        }
                    }
                }
                break;
        }
    }

    /*
     *  Funcion que recibe como parametro un caracter fila del tablero y retorna un entero el 
     *  cual esta representado para poder manejar la matriz del tablero 
     */
    private static int valor(char X)
    {
        switch(X)
        {
            case 'A':
                return 0;
                break;
            case 'B':
                return 1;
                break;
            case 'C':
                return 2;
                break;
            case 'D':
                return 3;
                break;
            case 'E':
                return 4;
                break;
            case 'F':
                return 5;
                break;
            case 'G':
                return 6;
                break;
            case 'H':
                return 7;
                break;
            case 'I':
                return 8;
                break;
            case 'J':
                return 9;
                break;
                default: return -1;

        }

    }

    /*
     *  Funcion que permite posicionar los navios en el tablero 
     */
    private static void tipoBarcos()
    {
        try
        {
            Console.WriteLine("    ELIJA SU OPCION");
            Console.WriteLine("    1.- Destructor       2.- Submarino       3.- Crucero     4.- Acorazado       5.- Porta Aviones");
            Console.Write("    Su opcion......:");
            colocarBarcos(Convert.ToInt32(Console.ReadLine()));
        }
        catch (Exception ex)
        {
            Console.WriteLine("    ┌─────────────────────────────────────────────────┐");
            Console.WriteLine("    │    PARAMETRO INGRESADO INCORRECTO !!!!!!!!!     │");
            Console.WriteLine("    └─────────────────────────────────────────────────┘");
            Thread.Sleep(3000);
        }        
    }

    /*
     *  Funcion que permite posicionar los navios en el tablero 
     */
    private static void tipoBarcosEnemigo()
    {
        try
        {
            Console.WriteLine("    ELIJA SU OPCION");
            Console.WriteLine("    1.- Destructor       2.- Submarino       3.- Crucero     4.- Acorazado       5.- Porta Aviones");
            Console.Write("    Su opcion......:");
            colocarBarcosEnemigo(Convert.ToInt32(Console.ReadLine()));
        }
        catch (Exception ex)
        {
            Console.WriteLine("    ┌─────────────────────────────────────────────────┐");
            Console.WriteLine("    │    PARAMETRO INGRESADO INCORRECTO !!!!!!!!!     │");
            Console.WriteLine("    └─────────────────────────────────────────────────┘");
            Thread.Sleep(3000);
        }
    }
}

