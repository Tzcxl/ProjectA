using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    public GameObject roomPrefab; // Префаб комнаты
    public int gridWidth = 9; // Ширина сетки
    public int gridHeight = 8; // Высота сетки
    public int numRooms = 10; // Количество комнат

    private bool[,] filledCells; // Массив для отслеживания заполненных ячеек
    private void Start()
    {
        filledCells = new bool[gridWidth, gridHeight];
        FillGrid();
    }

    private void FillGrid()
    {
        // Заполняем комнату 32 (индексация с 0)
        int startX = 3;
        int startY = 1;
        filledCells[startX, startY] = true;
        Instantiate(roomPrefab, new Vector3(startX, startY, 0), Quaternion.identity);

         // Проходим по всей сетке
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    // Проверяем, что текущая ячейка не заполнена
                    if (!filledCells[x, y])
                    {
                        // Случайно выбираем направление (вверх, вниз, влево или вправо)
                        int direction = UnityEngine.Random.Range(0, 4);
                        int newX = x;
                        int newY = y;

                        switch (direction)
                        {
                            case 0: // Вверх
                                newY++;
                                break;
                            case 1: // Вниз
                                newY--;
                                break;
                            case 2: // Влево
                                newX--;
                                break;
                            case 3: // Вправо
                                newX++;
                                break;
                        }

                        // Проверяем, что новая ячейка находится в пределах сетки
                        if (newX >= 0 && newX < gridWidth && newY >= 0 && newY < gridHeight)
                        {
                            filledCells[newX, newY] = true;
                            Instantiate(roomPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
                        }
                    }
                }
            }


        
        
    }
}

