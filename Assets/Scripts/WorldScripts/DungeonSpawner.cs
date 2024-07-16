using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    public GameObject roomPrefab; // ������ �������
    public int gridWidth = 9; // ������ �����
    public int gridHeight = 8; // ������ �����
    public int numRooms = 10; // ���������� ������

    private bool[,] filledCells; // ������ ��� ������������ ����������� �����
    private void Start()
    {
        filledCells = new bool[gridWidth, gridHeight];
        FillGrid();
    }

    private void FillGrid()
    {
        // ��������� ������� 32 (���������� � 0)
        int startX = 3;
        int startY = 1;
        filledCells[startX, startY] = true;
        Instantiate(roomPrefab, new Vector3(startX, startY, 0), Quaternion.identity);

         // �������� �� ���� �����
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    // ���������, ��� ������� ������ �� ���������
                    if (!filledCells[x, y])
                    {
                        // �������� �������� ����������� (�����, ����, ����� ��� ������)
                        int direction = UnityEngine.Random.Range(0, 4);
                        int newX = x;
                        int newY = y;

                        switch (direction)
                        {
                            case 0: // �����
                                newY++;
                                break;
                            case 1: // ����
                                newY--;
                                break;
                            case 2: // �����
                                newX--;
                                break;
                            case 3: // ������
                                newX++;
                                break;
                        }

                        // ���������, ��� ����� ������ ��������� � �������� �����
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

