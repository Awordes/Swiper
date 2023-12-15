namespace Swiper.Simulator.API;

public interface ISimulatorService
{
    void StartSimulation(int size);

    void StartSimulation(int size, int[][] field);

    int[][] GetMatrix();
    
    void SwipeUp();
}
