using Microsoft.Win32;
using System;
using System.Runtime.CompilerServices;

namespace Emulator
{
    class Cl16
    {
        static void Main()
        {
            Console.WriteLine("Witaj w emulatorze procesora Intel 8086.\nChcesz uzupelnic rejestry recznie czy mam wprowadzic losowe wartosci?\n(MANUAL, RANDOM)");  ////greeting the user
            string menuInstruction = Console.ReadLine().ToUpper();                                                                                                 ///waiting for the instruction
            int AX, BX, CX, DX;

            do
            {
                if (menuInstruction == "MANUAL")
                {
                    Console.Clear();
                    Console.WriteLine("Wprowadz wartosc dla AX");
                    AX = inputCheck();
                    Console.WriteLine("Wprowadz wartosc dla BX");                                                                                               ////manual input
                    BX = inputCheck();
                    Console.WriteLine("Wprowadz wartosc dla CX");
                    CX = inputCheck();
                    Console.WriteLine("Wprowadz wartosc dla DX");
                    DX = inputCheck();
                    break;
                }
                else if (menuInstruction == "RANDOM")
                {
                    Console.Clear();
                    Random randomNumber = new Random();
                    AX = randomNumber.Next(-65535, 65536);
                    BX = randomNumber.Next(-65535, 65536);
                    CX = randomNumber.Next(-65535, 65536);                                                                                         ////random input
                    DX = randomNumber.Next(-65535, 65536);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\n(MANUAL, RANDOM)");                                                              ////unknown menu instruction
                    menuInstruction = Console.ReadLine().ToUpper();
                }
            } while (true);

            Console.Clear();
            string systemChoice;
            Console.WriteLine("Wybierz system liczbowy, w ktorym maja byc wyswietlane rejestry.\n(BIN, DEC, HEX)");
            systemChoice = Console.ReadLine().ToUpper();

            do
            {
                if (systemChoice == "BIN")
                {
                    Console.Clear();
                    displayBinRegistry(AX, BX, CX, DX);
                    break;
                }
                else if (systemChoice == "DEC")
                {
                    Console.Clear();
                    displayDecRegistry(AX, BX, CX, DX);
                    break;
                }
                else if (systemChoice == "HEX")
                {                                                                                            ////first display
                    Console.Clear();
                    displayHexRegistry(AX, BX, CX, DX);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz system liczbowy, w ktorym maja byc wyswietlane rejestry.\n(BIN, DEC, HEX)");
                    systemChoice = Console.ReadLine().ToUpper();
                }

            } while (true);

            bool doLoop;                                                                                                          /////further operations
            do
            {
                doLoop = true;
                Console.WriteLine("Wybierz operacje ktora chcesz wykonac.\n(MOV, CMP, CLR, ADD, SUB, INC, DEC, XCHG)\n\nJesli chcesz zmienic wyswietlany system liczbowy wybierz SYSTEM.\nJesli chcesz wyjsc wybierz EXIT.");
                string operationInstruction = Console.ReadLine().ToUpper();                                                                                          ///waiting for the instruction
                switch (operationInstruction)
                {


                    case "MOV":
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz rejestr, ktory ma zostac przeniesiony.\n(AX, BX, CX, DX)");                                                          ///MOV - first value
                        string operation = Console.ReadLine().ToUpper();
                        int tempMovValue;
                        do
                        {
                            if (operation == "AX")
                            {
                                tempMovValue = Mov(AX);
                                AX = 0;
                                break;
                            }
                            else if (operation == "BX")
                            {
                                tempMovValue = Mov(BX);
                                BX = 0;
                                break;
                            }
                            else if (operation == "CX")
                            {
                                tempMovValue = Mov(CX);
                                CX = 0;
                                break;
                            }
                            else if (operation == "DX")
                            {
                                tempMovValue = Mov(DX);
                                DX = 0;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz wartosc, ktora ma zostac przeniesiona z rejestru.\n(AX, BX, CX, DX)");                                                         ///MOV - unknown command
                                operation = Console.ReadLine().ToUpper();
                            }

                        } while (true);
                        Console.WriteLine("Wybierz rejestr, do ktorego ma zostac przeniesiona wczesniej wybrana wartosc.\n(AX, BX, CX, DX)");
                        operation = Console.ReadLine().ToUpper();                                                                                        ///MOV - second value
                        do
                        {
                            if (operation == "AX")
                            {
                                AX = tempMovValue;
                                break;
                            }
                            else if (operation == "BX")
                            {
                                BX = tempMovValue;
                                break;
                            }
                            else if (operation == "CX")
                            {
                                CX = tempMovValue;
                                break;
                            }
                            else if (operation == "DX")
                            {
                                DX = tempMovValue;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz rejestr, do ktorego ma zostac przeniesiona wczesniej wybrana wartosc.\n(AX, BX, CX, DX)");                                               ///MOV - unknown command
                                operation = Console.ReadLine().ToUpper();
                            }

                        } while (true);
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        break;



                    case "CMP":
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz pierwszy rejestr do porownania.\n(AX, BX, CX, DX)");
                        operation = Console.ReadLine().ToUpper();                                                                                   ///CMP - first value
                        int compValue;
                        do
                        {
                            if (operation == "AX")
                            {
                                compValue = AX;
                                break;
                            }
                            else if (operation == "BX")
                            {
                                compValue = BX;
                                break;
                            }
                            else if (operation == "CX")
                            {
                                compValue = CX;
                                break;
                            }
                            else if (operation == "DX")
                            {
                                compValue = DX;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz pierwszy rejestr do porownania.\n(AX, BX, CX, DX)");                      ///CMP - unknown command
                                operation = Console.ReadLine().ToUpper();
                            }

                        } while (true);
                        Console.WriteLine("Wybierz drugi rejestr do porownania.\n(AX, BX, CX, DX)");
                        operation = Console.ReadLine().ToUpper();                                                                            ///CMP - second value
                        do
                        {
                            if (operation == "AX")
                            {
                                if (AX == compValue)
                                {
                                    Console.Clear();
                                    if (systemChoice == "BIN")
                                    {
                                        Console.Clear();
                                        displayBinRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "DEC")
                                    {
                                        Console.Clear();
                                        displayDecRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "HEX")
                                    {
                                        Console.Clear();
                                        displayHexRegistry(AX, BX, CX, DX);
                                    }
                                    Console.WriteLine("Wartosci rejestrow sa takie same.");
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    if (systemChoice == "BIN")
                                    {
                                        Console.Clear();
                                        displayBinRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "DEC")
                                    {
                                        Console.Clear();
                                        displayDecRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "HEX")
                                    {
                                        Console.Clear();
                                        displayHexRegistry(AX, BX, CX, DX);
                                    }
                                    Console.WriteLine("Wartosci rejestrow nie sa takie same.");
                                    break;
                                }
                            }
                            else if (operation == "BX")
                            {
                                if (BX == compValue)
                                {
                                    Console.Clear();
                                    if (systemChoice == "BIN")
                                    {
                                        Console.Clear();
                                        displayBinRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "DEC")
                                    {
                                        Console.Clear();
                                        displayDecRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "HEX")
                                    {
                                        Console.Clear();
                                        displayHexRegistry(AX, BX, CX, DX);
                                    }
                                    Console.WriteLine("Wartosci rejestrow sa takie same.");
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    if (systemChoice == "BIN")
                                    {
                                        Console.Clear();
                                        displayBinRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "DEC")
                                    {
                                        Console.Clear();
                                        displayDecRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "HEX")
                                    {
                                        Console.Clear();
                                        displayHexRegistry(AX, BX, CX, DX);
                                    }
                                    Console.WriteLine("Wartosci rejestrow nie sa takie same.");
                                    break;
                                }
                            }
                            else if (operation == "CX")
                            {
                                if (CX == compValue)
                                {
                                    Console.Clear();
                                    if (systemChoice == "BIN")
                                    {
                                        Console.Clear();
                                        displayBinRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "DEC")
                                    {
                                        Console.Clear();
                                        displayDecRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "HEX")
                                    {
                                        Console.Clear();
                                        displayHexRegistry(AX, BX, CX, DX);
                                    }
                                    Console.WriteLine("Wartosci rejestrow sa takie same.");
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    if (systemChoice == "BIN")
                                    {
                                        Console.Clear();
                                        displayBinRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "DEC")
                                    {
                                        Console.Clear();
                                        displayDecRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "HEX")
                                    {
                                        Console.Clear();
                                        displayHexRegistry(AX, BX, CX, DX);
                                    }
                                    Console.WriteLine("Wartosci rejestrow nie sa takie same.");
                                    break;
                                }
                            }
                            else if (operation == "DX")
                            {
                                if (DX == compValue)
                                {
                                    Console.Clear();
                                    if (systemChoice == "BIN")
                                    {
                                        Console.Clear();
                                        displayBinRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "DEC")
                                    {
                                        Console.Clear();
                                        displayDecRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "HEX")
                                    {
                                        Console.Clear();
                                        displayHexRegistry(AX, BX, CX, DX);
                                    }
                                    Console.WriteLine("Wartosci rejestrow sa takie same.");
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    if (systemChoice == "BIN")
                                    {
                                        Console.Clear();
                                        displayBinRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "DEC")
                                    {
                                        Console.Clear();
                                        displayDecRegistry(AX, BX, CX, DX);
                                    }
                                    else if (systemChoice == "HEX")
                                    {
                                        Console.Clear();
                                        displayHexRegistry(AX, BX, CX, DX);
                                    }
                                    Console.WriteLine("Wartosci rejestrow nie sa takie same.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz drugi rejestr do porownania.\n(AX, BX, CX, DX)");             ///CMP - unknown command                                                ///CMP - unknown command
                                operation = Console.ReadLine().ToUpper();
                            }

                        } while (true);
                        break;



                    case "CLR":
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz rejestr ktory chcesz wyzerowac.\n(AX, BX, CX, DX)");                    ///CLR - first value
                        operation = Console.ReadLine().ToUpper();
                        do
                        {
                            if (operation == "AX")
                            {
                                AX = 0;
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                break;
                            }
                            else if (operation == "BX")
                            {
                                BX = 0;
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                break;
                            }
                            else if (operation == "CX")
                            {
                                CX = 0;
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                break;
                            }
                            else if (operation == "DX")
                            {
                                DX = 0;
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz rejestr ktory chcesz wyzerowac.\n(AX, BX, CX, DX)");         ////CLR - unknown command
                                operation = Console.ReadLine().ToUpper();
                            }

                        } while (true);
                        break;


                    case "ADD":
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz pierwszy rejestr do dodania.\n(AX, BX, CX, DX)");                            ////ADD - first value
                        string sumOperation1 = Console.ReadLine().ToUpper();
                        int firstSumValue;
                        do
                        {
                            if (sumOperation1 == "AX")
                            {
                                firstSumValue = AX;
                                break;
                            }
                            else if (sumOperation1 == "BX")
                            {
                                firstSumValue = BX;
                                break;
                            }
                            else if (sumOperation1 == "CX")
                            {
                                firstSumValue = CX;
                                break;
                            }
                            else if (sumOperation1 == "DX")
                            {
                                firstSumValue = DX;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz pierwszy rejestr do dodania.\n(AX, BX, CX, DX)");     ///ADD - unknown command
                                sumOperation1 = Console.ReadLine().ToUpper();
                                
                            }
                        } while (true);
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz rejestr, ktorego wartosc chcesz dodac do pierwszego wybranego rejestru.\n(AX, BX, CX, DX)");                            ////ADD - second value
                        operation = Console.ReadLine().ToUpper();
                        int secondSumValue;
                        do
                        {
                            if (operation == "AX")
                            {
                                secondSumValue = AX;
                                break;
                            }
                            else if (operation == "BX")
                            {
                                secondSumValue = BX;
                                break;
                            }
                            else if (operation == "CX")
                            {
                                secondSumValue = CX;
                                break;
                            }
                            else if (operation == "DX")
                            {
                                secondSumValue = DX;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz rejestr, ktorego wartosc chcesz dodac do pierwszego wybranego rejestru.\n(AX, BX, CX, DX)");     ///ADD - unknown command
                                operation = Console.ReadLine().ToUpper();
                            }
                        } while (true);

                        if (sumOperation1 == "AX")
                        {
                            AX = Sum(firstSumValue, secondSumValue);
                        }
                        else if (sumOperation1 == "BX")
                        {
                            BX = Sum(secondSumValue, firstSumValue);
                        }
                        else if (sumOperation1 == "CX")
                        {
                            CX = Sum(firstSumValue, secondSumValue);
                        }
                        else if (sumOperation1 == "DX")
                        {
                            DX = Sum(secondSumValue, firstSumValue);
                        }
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        break;
                    case "SUB":
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz pierwszy rejestr do odjecia.\n(AX, BX, CX, DX)");                            ////SUB - first value
                        string subOperation1 = Console.ReadLine().ToUpper();
                        int firstSubValue;
                        do
                        {
                            if (subOperation1 == "AX")
                            {
                                firstSubValue = AX;
                                break;
                            }
                            else if (subOperation1 == "BX")
                            {
                                firstSubValue = BX;
                                break;
                            }
                            else if (subOperation1 == "CX")
                            {
                                firstSubValue = CX;
                                break;
                            }
                            else if (subOperation1 == "DX")
                            {
                                firstSubValue = DX;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz pierwszy rejestr do odjecia.\n(AX, BX, CX, DX)");     ///SUB - unknown command
                                subOperation1 = Console.ReadLine().ToUpper();
                            }
                        } while (true);
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz rejestr, ktorego wartosc odejmiesz do pierwszego wybranego rejestru.\n(AX, BX, CX, DX)");                            ////SUB - second value
                        operation = Console.ReadLine().ToUpper();
                        int secondSubValue;
                        do
                        {
                            if (operation == "AX")
                            {
                                secondSubValue = AX;
                                break;
                            }
                            else if (operation == "BX")
                            {
                                secondSubValue = BX;
                                break;
                            }
                            else if (operation == "CX")
                            {
                                secondSubValue = CX;
                                break;
                            }
                            else if (operation == "DX")
                            {
                                secondSubValue = DX;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz rejestr, ktorego wartosc odejmiesz do pierwszego wybranego rejestru.\n(AX, BX, CX, DX)");     ///SUB - unknown command
                                operation = Console.ReadLine().ToUpper();
                            }
                        } while (true);

                        if (subOperation1 == "AX")
                        {
                            AX = Sub(firstSubValue, secondSubValue);
                        }
                        else if (subOperation1 == "BX")
                        {
                            BX = Sub(firstSubValue, secondSubValue);
                        }
                        else if (subOperation1 == "CX")
                        {
                            CX = Sub(firstSubValue, secondSubValue);
                        }
                        else if (subOperation1 == "DX")
                        {
                            DX = Sub(firstSubValue, secondSubValue);
                        }
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        break;


                    case "INC":
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz rejestr ktory chcesz poddac inkrementacji.\n(AX, BX, CX, DX)");                                             ///INC - first value
                        operation = Console.ReadLine().ToUpper();
                        do
                        {
                            if (operation == "AX")
                            {
                                AX++;
                                break;
                            }
                            else if (operation == "BX")
                            {
                                BX++;
                                break;
                            }
                            else if (operation == "CX")
                            {
                                CX++;
                                break;
                            }
                            else if (operation == "DX")
                            {
                                DX++;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz rejestr ktory chcesz poddac inkrementacji.\n(AX, BX, CX, DX)");                  ///INC - unknown command
                                operation = Console.ReadLine().ToUpper();
                            }
                        } while (true);
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        break;



                    case "DEC":
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz rejestr ktory chcesz poddac dekrementacji.\n(AX, BX, CX, DX)");                 ////DEC - first value
                        operation = Console.ReadLine().ToUpper();
                        do
                        {
                            if (operation == "AX")
                            {
                                AX--;
                                break;
                            }
                            else if (operation == "BX")
                            {
                                BX--;
                                break;
                            }
                            else if (operation == "CX")
                            {
                                CX--;
                                break;
                            }
                            else if (operation == "DX")
                            {
                                DX--;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz rejestr ktory chcesz poddac dekrementacji.\n(AX, BX, CX, DX)");                ///DEC - unknown command
                                operation = Console.ReadLine().ToUpper();
                            }
                        } while (true);
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        break;



                    case "XCHG":
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Wybierz pierwszy rejestr, ktory chcesz zamienic miejscem.\n(AX, BX, CX, DX)");                   ///XCHG - first value
                        string firstXCHGoperation = Console.ReadLine().ToUpper();
                        int tempXCHGFirstValue;
                        do
                        {
                            if (firstXCHGoperation == "AX")
                            {
                                tempXCHGFirstValue = AX;
                                break;
                            }
                            else if (firstXCHGoperation == "BX")
                            {
                                tempXCHGFirstValue = BX;
                                break;
                            }
                            else if (firstXCHGoperation == "CX")
                            {
                                tempXCHGFirstValue = CX;
                                break;
                            }
                            else if (firstXCHGoperation == "DX")
                            {
                                tempXCHGFirstValue = DX;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz pierwszy rejestr, ktory chcesz zamienic miejscem.\n(AX, BX, CX, DX)");         ///XCHG - unknown command
                                firstXCHGoperation = Console.ReadLine().ToUpper();
                            }
                        } while (true);
                        Console.WriteLine("Wybierz pierwszy rejestr, ktory chcesz zamienic miejscem z pierwszym wybranym rejesterem.\n(AX, BX, CX, DX)");                                  //////XCHG - second value
                        string secondXCHGoperation = Console.ReadLine().ToUpper();
                        int tempXCHGSecondValue;
                        do
                        {
                            if (secondXCHGoperation == "AX")
                            {
                                tempXCHGSecondValue = AX;
                                break;
                            }
                            else if (secondXCHGoperation == "BX")
                            {
                                tempXCHGSecondValue = BX;
                                break;
                            }
                            else if (secondXCHGoperation == "CX")
                            {
                                tempXCHGSecondValue = CX;
                                break;
                            }
                            else if (secondXCHGoperation == "DX")
                            {
                                tempXCHGSecondValue = DX;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                if (systemChoice == "BIN")
                                {
                                    Console.Clear();
                                    displayBinRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "DEC")
                                {
                                    Console.Clear();
                                    displayDecRegistry(AX, BX, CX, DX);
                                }
                                else if (systemChoice == "HEX")
                                {
                                    Console.Clear();
                                    displayHexRegistry(AX, BX, CX, DX);
                                }
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie.\nWybierz pierwszy rejestr, ktory chcesz zamienic miejscem z pierwszym wybranym rejesterem.\n(AX, BX, CX, DX)");     ///XCHG - logic
                                secondXCHGoperation = Console.ReadLine().ToUpper();
                            }
                        } while (true);
                        if (firstXCHGoperation == "AX")
                        {
                            AX = tempXCHGSecondValue;

                        }
                        else if (firstXCHGoperation == "BX")
                        {
                            BX = tempXCHGSecondValue;

                        }
                        else if (firstXCHGoperation == "CX")
                        {
                            CX = tempXCHGSecondValue;

                        }
                        else if (firstXCHGoperation == "DX")
                        {
                            DX = tempXCHGSecondValue;

                        }
                        if (secondXCHGoperation == "AX")
                        {
                            AX = tempXCHGFirstValue;

                        }
                        else if (secondXCHGoperation == "BX")
                        {
                            BX = tempXCHGFirstValue;

                        }
                        else if (secondXCHGoperation == "CX")
                        {
                            CX = tempXCHGFirstValue;

                        }
                        else if (secondXCHGoperation == "DX")
                        {
                            DX = tempXCHGFirstValue;

                        }
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        break;
                    case "SYSTEM":
                        Console.Clear();
                        Console.WriteLine("Wybierz system liczbowy, w ktorym maja byc wyswietlane rejestry.\n(BIN, DEC, HEX)");
                        systemChoice = Console.ReadLine().ToUpper();

                        do
                        {
                            if (systemChoice == "BIN")
                            {
                                Console.Clear();
                                displayBinRegistry(AX, BX, CX, DX);
                                break;
                            }
                            else if (systemChoice == "DEC")
                            {
                                Console.Clear();
                                displayDecRegistry(AX, BX, CX, DX);
                                break;
                            }
                            else if (systemChoice == "HEX")
                            {                                                                                            ////switching system
                                Console.Clear();
                                displayHexRegistry(AX, BX, CX, DX);
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Polecenie nieznane, sprobuj ponownie\nWybierz system liczbowy, w ktorym maja byc wyswietlane rejestry.\n(BIN, DEC, HEX)");
                                systemChoice = Console.ReadLine().ToUpper();
                            }

                        } while (true);
                        break;
                    case "EXIT":
                        doLoop = false;
                        break;
                    default:
                        doLoop = true;
                        Console.Clear();
                        if (systemChoice == "BIN")
                        {
                            Console.Clear();
                            displayBinRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "DEC")
                        {
                            Console.Clear();
                            displayDecRegistry(AX, BX, CX, DX);
                        }
                        else if (systemChoice == "HEX")
                        {
                            Console.Clear();
                            displayHexRegistry(AX, BX, CX, DX);
                        }
                        Console.WriteLine("Polecenie nieznane, sprobuj ponownie.");
                        break;
                }
            } while (doLoop == true);
        }
        static int inputCheck()
        {
            do
            {
                bool value = int.TryParse(Console.ReadLine(), out int number);
                if (value == true)
                {
                    do
                    {
                        if (number >= -65535 && number < 65536)
                        {
                            return number;
                        }
                        else if (number < -65535)
                        {
                            Console.WriteLine("Wartosc jest za mala, sprobuj ponownie");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wartosc jest za duza, sprobuj ponownie");
                            break;
                        }
                    } while (true);
                }
                else
                {
                    Console.WriteLine("Nieprawidlowa wartosc, sprobuj ponownie");
                }
            } while (true);
        }

        static void displayBinRegistry(int ax, int bx, int cx, int dx)
        {
            short systemBase = 2;
            string convax = Convert.ToString(ax, systemBase).ToUpper();
            string convbx = Convert.ToString(bx, systemBase).ToUpper();
            string convcx = Convert.ToString(cx, systemBase).ToUpper();
            string convdx = Convert.ToString(dx, systemBase).ToUpper();
            string final = "AX:     " + convax + "\nBX:     " + convbx + "\nCX:     " + convcx + "\nDX:     " + convdx + "\n";
            Console.WriteLine(final, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void displayDecRegistry(int ax, int bx, int cx, int dx)
        {
            short systemBase = 10;
            string convax = Convert.ToString(ax, systemBase).ToUpper();
            string convbx = Convert.ToString(bx, systemBase).ToUpper();
            string convcx = Convert.ToString(cx, systemBase).ToUpper();
            string convdx = Convert.ToString(dx, systemBase).ToUpper();
            string final = "AX:     " + convax + "\nBX:     " + convbx + "\nCX:     " + convcx + "\nDX:     " + convdx + "\n";
            Console.WriteLine(final, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void displayHexRegistry(int ax, int bx, int cx, int dx)
        {
            short systemBase = 16;
            string convax = Convert.ToString(ax, systemBase).ToUpper();
            string convbx = Convert.ToString(bx, systemBase).ToUpper();
            string convcx = Convert.ToString(cx, systemBase).ToUpper();
            string convdx = Convert.ToString(dx, systemBase).ToUpper();
            string final = "AX:     " + convax + "\nBX:     " + convbx + "\nCX:     " + convcx + "\nDX:     " + convdx + "\n";
            Console.WriteLine(final, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static int Mov(int ax)
        {
            int tempValue = ax;
            return tempValue;
        }
        static int Sum(int valueFirst, int valueSecond)
        {
            int finalValue;
            finalValue = valueFirst + valueSecond;
            return finalValue;
        }
        static int Sub(int valueFirst, int valueSecond)
        {
            int finalValue;
            finalValue = valueFirst - valueSecond;
            return finalValue;
        }
    }
}
