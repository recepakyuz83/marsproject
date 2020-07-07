using System;
using System.Collections.Generic;
using MarsProject;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MarsProject.Program;

namespace MarsRoverUnitTestProject
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]      
        public void TestFirstCommand()
        {
            Program marsProgram = new Program()
            {
                X = 1,
                Y = 2,
                Direction = Directions.N
            };

            var maxCoordinates = new List<int>() { 5, 5 };
            var commands = "LMLMLMLMM";

            marsProgram.move(maxCoordinates, commands);

            var output = $"{marsProgram.X} {marsProgram.Y} {marsProgram.Direction.ToString()}";
            var expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void TestSecondCommand()
        {
            Program marsProgram = new Program()
            {
                X = 3,
                Y = 3,
                Direction = Directions.E
            };

            var maxCoordinates = new List<int>() { 5, 5 };
            var commands = "MRRMMRMRRM";

            marsProgram.move(maxCoordinates, commands);

            var output = $"{marsProgram.X} {marsProgram.Y} {marsProgram.Direction.ToString()}";
            var expectedOutput = "2 3 S";

            Assert.AreEqual(expectedOutput,output);
        }

    }
}
