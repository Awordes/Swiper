namespace Swiper.Simulator.API;

public interface ISimulatorService
{
    void StartSimulation(int size);

    void StartSimulation(int size, int[][] field);

    int[][] GetMatrix();

    void AddValueInMatrix(int value, int valueX, int valueY);
    
    void SwipeUp();

    void SwipeDown();

    void SwipeLeft();

    void SwipeRight();
}
