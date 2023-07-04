using System;
using Xunit;
using TechTalk.SpecFlow;
using FluentAssertions;
using SpaceBattle;

namespace SpaceBattle.TestsBDD.Steps
{
    [Binding]
    public sealed class SpaceBattle_TestsBDD
    {

        private SpaceShip _spaceShip = new SpaceShip();
        private Exception _actualException = new Exception();


        [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
        public void SpaceShipSetCoordinates(double x, double y)
        {
            _spaceShip.SetCoordinates(new double[2] { x, y });
        }

        [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
        public void SpaceShipSetSpeed(double x, double y)
        {

            _spaceShip.SetSpeed(new double[2] { x, y });

        }


        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void MovementSpaceShip()
        {
            try
            {
                _spaceShip.ChangeCoordinates();
            }
            catch (Exception a)
            {
                _actualException = a;
            }
        }
        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void SpaceShipMoveDot(double x, double y)
        {
            var newCoordinates = new double[] { x, y };
            for (int i = 0; i < 2; i++)
            {
                Assert.Equal(_spaceShip.Coordinates[i], newCoordinates[i]);
            }
        }
        [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
        public void UndefinedLocation()
        {
            _spaceShip.SetCoordinates(new double[2] { double.NaN, double.NaN });
        }
        [Given(@"скорость корабля определить невозможно")]
        public void UndefinedSpeed()
        {
            _spaceShip.SetSpeed(new double[2] { double.NaN, double.NaN });
        }
        [Then(@"возникает ошибка Exception")]
        public void ErrorException()
        {
            Assert.ThrowsAsync<Exception>(() => throw _actualException);
        }
        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void CantMove()
        {
            _spaceShip.Speed = new double[2] { double.NaN, double.NaN };
        }

    }
}