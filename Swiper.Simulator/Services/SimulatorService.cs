using Swiper.Simulator.API;

namespace Swiper.Simulator.Services;

internal class SimulatorService : ISimulatorService
{
    private int[][] _matrix;
    private int _size;

    public SimulatorService()
    {
        _matrix = [];
    }

    public void StartSimulation(int size)
    {
        _size = size;
        _matrix = new int[_size][];

        for (int i = 0; i < _size; i++)
            _matrix[i] = new int[_size];
    }

    public void StartSimulation(int size, int[][] field)
    {
        _size = size;
        _matrix = new int[_size][];

        for (int i = 0; i < _size; i++)
        {
            _matrix[i] = new int[_size];

            for (int j = 0; j < _size; j++)
                _matrix[i][j] = field[i][j];
        }
    }

    public int[][] GetMatrix() => _matrix;
    
    public void AddValueInMatrix(int value, int valueX, int valueY)
    {
        if (valueX >= _size || valueY >= _size)
            throw new Exception("Wrong coordinates");
        
        _matrix[valueY][valueX] = value;
    }

    public void SwipeUp()
    {
        for (int j = 0; j < _size; j++)
        {
            int i = 0;
            int mark = i + 1;

            do
            {
                if (_matrix[mark][j] == 0)
                {
                    mark++;
                    continue;
                }

                if (_matrix[i][j] == 0)
                {
                    _matrix[i][j] = _matrix[mark][j];
                    _matrix[mark][j] = 0;
                    mark++;
                    continue;
                }

                if (_matrix[i][j] == _matrix[mark][j])
                {
                    _matrix[i][j] *= 2;
                    _matrix[mark][j] = 0;
                }

                i++;
                mark = i + 1;
            } 
            while (i < _size && mark < _size);
        }
    }

    public void SwipeDown()
    {
        for (int j = _size - 1; j > -1; j--)
        {
            int i = _size - 1;
            int mark = i - 1;

            do
            {
                if (_matrix[mark][j] == 0)
                {
                    mark--;
                    continue;
                }

                if (_matrix[i][j] == 0)
                {
                    _matrix[i][j] = _matrix[mark][j];
                    _matrix[mark][j] = 0;
                    mark--;
                    continue;
                }

                if (_matrix[i][j] == _matrix[mark][j])
                {
                    _matrix[i][j] *= 2;
                    _matrix[mark][j] = 0;
                }
                
                i--;
                mark = i - 1;
            } 
            while (i > -1 && mark > -1);
        }
    }

    public void SwipeLeft()
    {
        for (int j = 0; j < _size; j++)
        {
            int i = 0;
            int mark = i + 1;

            do
            {
                if (_matrix[j][mark] == 0)
                {
                    mark++;
                    continue;
                }

                if (_matrix[j][i] == 0)
                {
                    _matrix[j][i] = _matrix[j][mark];
                    _matrix[j][mark] = 0;
                    mark++;
                    continue;
                }

                if (_matrix[j][i] == _matrix[j][mark])
                {
                    _matrix[j][i] *= 2;
                    _matrix[j][mark] = 0;
                }
                
                i++;
                mark = i + 1;
            } 
            while (i < _size && mark < _size);
        }
    }

    public void SwipeRight()
    {
        for (int j = _size - 1; j > -1; j--)
        {
            int i = _size - 1;
            int mark = i - 1;

            do
            {
                if (_matrix[j][mark] == 0)
                {
                    mark--;
                    continue;
                }

                if (_matrix[j][i] == 0)
                {
                    _matrix[j][i] = _matrix[j][mark];
                    _matrix[j][mark] = 0;
                    mark--;
                    continue;
                }

                if (_matrix[j][i] == _matrix[j][mark])
                {
                    _matrix[j][i] *= 2;
                    _matrix[j][mark] = 0;
                }
                
                i--;
                mark = i - 1;
            } 
            while (i > -1 && mark > -1);
        }
    }
}
