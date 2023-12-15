using Microsoft.Extensions.DependencyInjection;
using Swiper.Simulator;
using Swiper.Simulator.API;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSimulator();
var serviceProvider = serviceCollection.BuildServiceProvider();
var simulatorService = serviceProvider.GetRequiredService<ISimulatorService>();