char[,] gr = new char[,] {
                { '+', '-' ,'+', '-', '+', '-', '+' },
                { '|', '1', '|', '2', '|', '3', '|' },
                { '+', '-', '+', '-', '+', '-', '+' },
                { '|', '4', '|', '5', '|', '6', '|' },
                { '+', '-', '+', '-', '+', '-', '+' },
                { '|', '7', '|', '8', '|', '9', '|' },
                { '+', '-', '+', '-', '+', '-', '+' }
};
int rows = gr.GetUpperBound(1) + 1;    // количество строк
int columns = gr.Length / rows;        // количество столбцов
int count = 0;
int[] index = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
char x = 'x';
char o = 'o';
int positionX = 1;
int positionO = -1;
int winX = 0;
int winO = 0;
Random rnd = new Random();
int initiativeX = rnd.Next();
int initiativeO = rnd.Next();
bool stateX = false;
bool stateO = false;
bool ai = false; // ии всегда ходит 0
bool stateAI = false;
int n = 0;


void rander()
{

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (count == 7)
            {
                Console.Write("\n"); // перенос строки
                count = 0; //счётчик = 0 после того как он достиг 7
            }
            Console.Write(gr[i, j]);
            count++; // счётчик +1 до значения 7
        }

    }
    LogFight();
}

void test()
{
    /*замена символа*/
    if (index[0] == 1)
        gr[1, 1] = x;
    else if (index[0] == -1)
        gr[1, 1] = o;
    if (index[1] == 1)
        gr[1, 3] = x;
    else if (index[1] == -1)
        gr[1, 3] = o;
    if (index[2] == 1)
        gr[1, 5] = x;
    else if (index[2] == -1)
        gr[1, 5] = o;
    if (index[3] == 1)
        gr[3, 1] = x;
    else if (index[3] == -1)
        gr[3, 1] = o;
    if (index[4] == 1)
        gr[3, 3] = x;
    else if (index[4] == -1)
        gr[3, 3] = o;
    if (index[5] == 1)
        gr[3, 5] = x;
    else if (index[5] == -1)
        gr[3, 5] = o;
    if (index[6] == 1)
        gr[5, 1] = x;
    else if (index[6] == -1)
        gr[5, 1] = o;
    if (index[7] == 1)
        gr[5, 3] = x;
    else if (index[7] == -1)
        gr[5, 3] = o;
    if (index[8] == 1)
        gr[5, 5] = x;
    else if (index[8] == -1)
        gr[5, 5] = o;
    /*условия победы*/
    /*для х*/
    if (index[0] == 1 && index[3] == 1 && index[6] == 1 || index[1] == 1 && index[4] == 1 && index[7] == 1 || index[2] == 1 && index[5] == 1 && index[8] == 1) // по вертикали
    {
        winX = 1;
    }
    else if (index[0] == 1 && index[1] == 1 && index[2] == 1 || index[3] == 1 && index[4] == 1 && index[5] == 1 || index[6] == 1 && index[7] == 1 && index[8] == 1) // по горизонтали
    {
        winX = 1;
    }
    else if (index[0] == 1 && index[4] == 1 && index[8] == 1 || index[2] == 1 && index[4] == 1 && index[6] == 1) // по диагонали
    {
        winX = 1;
    }
    /*для o*/
    if (index[0] == -1 && index[3] == -1 && index[6] == -1 || index[1] == -1 && index[4] == -1 && index[7] == -1 || index[2] == -1 && index[5] == -1 && index[8] == -1) // по вертикали
    {
        winO = 1;
    }
    else if (index[0] == -1 && index[1] == -1 && index[2] == -1 || index[3] == -1 && index[4] == -1 && index[5] == -1 || index[6] == -1 && index[7] == -1 && index[8] == -1) // по горизонтали
    {
        winO = 1;
    }
    else if (index[0] == -1 && index[4] == -1 && index[8] == -1 || index[2] == -1 && index[4] == -1 && index[6] == -1) // по диагонали
    {
        winO = 1;
    }

    Console.Clear();
    /*если кто-то победил*/
    if (winX == 1)
    {
        Console.WriteLine();
        Console.WriteLine("Победили Х!!!");
        Console.ReadKey();
        stateO = false;
        stateX = false;
        stateAI = false;
        winX = 0;
        gr[1, 1] = '1';
        gr[1, 3] = '2';
        gr[1, 5] = '3';
        gr[3, 1] = '4';
        gr[3, 3] = '5';
        gr[3, 5] = '6';
        gr[5, 1] = '7';
        gr[5, 3] = '8';
        gr[5, 5] = '9';
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = 0;
        }
        Menu();
    }
    else if (winO == 1)
    {
        Console.WriteLine();
        Console.WriteLine("Победили O!!!");
        Console.ReadKey();
        stateO = false;
        stateX = false;
        stateAI = false;
        winO = 0;
        gr[1, 1] = '1';
        gr[1, 3] = '2';
        gr[1, 5] = '3';
        gr[3, 1] = '4';
        gr[3, 3] = '5';
        gr[3, 5] = '6';
        gr[5, 1] = '7';
        gr[5, 3] = '8';
        gr[5, 5] = '9';
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = 0;
        }
        Menu();
    }
    /*условие ничьей*/
    if (index[0] != 0 && index[1] != 0 && index[2] != 0 && index[3] != 0 && index[4] != 0 && index[5] != 0 && index[6] != 0 && index[7] != 0 && index[8] != 0)
    {
        Console.WriteLine("Ничья!");
        Console.ReadKey();
        stateO = false;
        stateX = false;
        stateAI = false;
        gr[1, 1] = '1';
        gr[1, 3] = '2';
        gr[1, 5] = '3';
        gr[3, 1] = '4';
        gr[3, 3] = '5';
        gr[3, 5] = '6';
        gr[5, 1] = '7';
        gr[5, 3] = '8';
        gr[5, 5] = '9';
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = 0;
        }
        Menu();
    }
    rander();
}

void LogFight() /*определяет, кто ходит первый*/
{
    if (ai == true)
    {
        AI();
    }
    else
    {
        if (initiativeX >= initiativeO)
        {
            xLog();
        }
        else
        {
            oLog();
        }
    }
}

void AI()
{
    while (true)
    {
        if (stateX == true)
        {
            stateX = false;
            AI();
        }
        else if (stateAI == true)
        {
            stateAI = false;
            xLog();
        }

        Random rnd1 = new Random();
        int n = rnd.Next(1, 9);
        if (index[n - 1] == 0)
        {
            index[n - 1] = -1;
        }
        else
        {
            continue;
        }
        stateAI = true;
        test();
    }
}

void xLog()
{
    while (true)
    {
        if (stateX == true)
        {
            stateX = false;
            oLog();
        }
        else if (stateO == true)
        {
            stateO = false;
            xLog();
        }
        Console.WriteLine();
        Console.WriteLine("Ход х. Выберите номер поля:");
        
        int n = int.Parse(Console.ReadLine());
        
        if (index[n - 1] == 0)
        {
            index[n - 1] = 1;
        }
        else
        {
            Console.WriteLine("Это поле занято");
            continue;
        }
        stateX = true;
        test();

    }
}

void oLog()
{
    while (true)
    {
        if (stateX == true)
        {
            stateX = false;
            oLog();
        }
        else if (stateO == true)
        {
            stateO = false;
            xLog();
        }
        Console.WriteLine();
        Console.WriteLine("Ход о. Выберите номер поля:");
        int n = int.Parse(Console.ReadLine());
        if (index[n - 1] == 0)
        {
            index[n - 1] = -1;
        }
        else
        {
            Console.WriteLine("Это поле занято");
            continue;
        }
        stateO = true;
        test();
    }
}

void Menu()
{
    Console.Clear();
    Console.WriteLine("Выберите режим:\n(1) 1 игрок               (2) 2 игрока");
    switch (Convert.ToInt16(Console.ReadLine()))
    {
        case 1:
            ai = true;
            break;
        case 2:
            ai = false;
            break;
    }

    rander();
}
Menu();