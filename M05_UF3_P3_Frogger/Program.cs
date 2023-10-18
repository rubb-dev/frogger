using System;
using System.Collections.Generic;
using System.Linq;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Utils.MAP_HEIGHT = 14;//Ajustael largo del juego
            // Ajustar el tamaño de la consola
            Console.SetWindowSize((Utils.MAP_WIDTH) , Utils.MAP_HEIGHT); 
            
            List<Lane> lanes = new List<Lane>();
            lanes.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0f, ' ', new List<ConsoleColor>()));
            lanes.Add(new Lane(1, true, ConsoleColor.DarkBlue, false, true, 0.45f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(2, true, ConsoleColor.DarkBlue, false, true, 0.65f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(3, true, ConsoleColor.DarkBlue, false, true, 0.45f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(4, true, ConsoleColor.DarkBlue, false, true, 0.55f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(5, true, ConsoleColor.DarkBlue, false, true, 0.65f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0f, ' ', new List<ConsoleColor>()));
            lanes.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.12f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.15f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.17f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(12, false, ConsoleColor.Black, true, false, 0.15f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(13, false, ConsoleColor.DarkGreen, false, false, 0f, ' ', new List<ConsoleColor>()));
            
            Player player = new Player();

            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;//Establece el estado del juego corriendo
            while (gameState == Utils.GAME_STATE.RUNNING)//Comprueba si el estado es corriendo y si no es sale del bucle cuando gana o pierde
            {
                TimeManager.NextFrame();//Actualiza la pantalla

                for (int i = 0; i < lanes.Count; i++) //Va dibujando y actualizando las lineas cada frame
                {
                    lanes[i].Draw();
                    lanes[i].Update(); 
                }


                player.Draw(lanes);//Dibuja al jugador
                Vector2Int inputDir = Utils.Input();//Recoge los inputs
                gameState = player.Update(inputDir, lanes);//Actualiza el estado del juego
            }

            Console.Clear();//Limpia la consola
            Console.SetCursorPosition(0, Utils.MAP_HEIGHT);//Coloca el cursor en las cordenadas q le pasamos
            if (gameState == Utils.GAME_STATE.WIN)//Si el estado de juego cambia ha WIN muestra el mensaje ¡Has ganado!
            {
                Console.WriteLine("¡Has ganado!");
            }
            else//Si el estado de juego cambia ha LOSE muestra el mensaje ¡Has perdido!
            {
                Console.WriteLine("¡Has perdido!");
            }

        }
    }
}
