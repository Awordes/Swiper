using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Swiper.Simulator;
using Swiper.Simulator.API;

namespace Swiper.Tests;

public class SwiperSimulatorTests
{
    [Fact]
    public void SwipeUp_ShouldSwipeUp()
    {
        var serviceProvider = BuildServiceProvider();

        var simulatorService = serviceProvider.GetRequiredService<ISimulatorService>();

        var size = 4;
        var input = new int[size][];
        input[0] = [4, 0, 2, 2];
        input[1] = [0, 2, 4, 2];
        input[2] = [4, 2, 2, 4];
        input[3] = [2, 4, 2, 4];

        var expect = new int[size][];        
        expect[0] = [8, 4, 2, 4];
        expect[1] = [2, 4, 4, 8];
        expect[2] = [0, 0, 4, 0];
        expect[3] = [0, 0, 0, 0];

        simulatorService.StartSimulation(size, input);
        simulatorService.SwipeUp();
        var result = simulatorService.GetMatrix();
        
        Assert.Equal(expect, result);
    }
    
    [Fact]
    public void SwipeDown_ShouldSwipeDown()
    {
        var serviceProvider = BuildServiceProvider();

        var simulatorService = serviceProvider.GetRequiredService<ISimulatorService>();

        var size = 4;
        var input = new int[size][];
        input[0] = [4, 0, 2, 2];
        input[1] = [0, 2, 4, 2];
        input[2] = [4, 2, 2, 4];
        input[3] = [2, 4, 2, 4];

        var expect = new int[size][];        
        expect[0] = [0, 0, 0, 0];
        expect[1] = [0, 0, 2, 0];
        expect[2] = [8, 4, 4, 4];
        expect[3] = [2, 4, 4, 8];

        simulatorService.StartSimulation(size, input);
        simulatorService.SwipeDown();
        var result = simulatorService.GetMatrix();
        
        Assert.Equal(expect, result);
    }

    private static ServiceProvider BuildServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSimulator();
        return serviceCollection.BuildServiceProvider();
    } 
}