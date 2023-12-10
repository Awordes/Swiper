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
}
