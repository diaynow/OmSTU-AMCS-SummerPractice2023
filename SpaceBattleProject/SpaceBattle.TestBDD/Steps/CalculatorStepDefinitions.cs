using System;
using Xunit;
using TechTalk.SpecFlow;
using FluentAssertions;
using SpaceBattle;

namespace SpaceBattle.TestsBDD.Steps
{
    [Binding, Scope(Feature = "Движение")]
    public sealed class SpaceBattle_Move
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
    [Binding, Scope(Feature = "Топливо")]
    public class SpaceBattle_Fuel
    {
        private SpaceShip _spaceShip = new SpaceShip();
        private Exception _actualException = new Exception();
        [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
        public void СapacityFuel(int a)
        {
            _spaceShip.SetFuel(a);
        }
        [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
        public void ConsumptionFuel(int a)
        {
            _spaceShip.SetConsumptionFuel(a);
        }
        [Then(@"новый объем топлива космического корабля равен (.*) ед")]
        public void NewCapacityFuel(int a)
        {
            Assert.Equal(_spaceShip.Fuel, a);
        }
        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void MovementSpaceShip()
        {
            try
            {
                _spaceShip.ChangeFuel();
            }
            catch (Exception a)
            {
                _actualException = a;
            }
        }
        [Then(@"возникает ошибка Exception")]
        public void ErrorException()
        {
            Assert.ThrowsAsync<Exception>(() => throw _actualException);
        }
    }
    [Binding, Scope(Feature = "Поворот")]
    public class SpaceBattle_Spin
    {
        private SpaceShip _spaceShip = new SpaceShip();
        private Exception _actualException = new Exception();
        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void CornerShip(int a)
        {
            _spaceShip.SetCorner(a);
        }
        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void CornerSpeedShip(int a)
        {
            _spaceShip.SetCornerSpeed(a);
        }
        [When(@"происходит вращение вокруг собственной оси")]
        public void ChangeCornerShip()
        {
            try
            {
                _spaceShip.ChangeCorner();
            }
            catch (Exception a)
            {
                _actualException = a;
            }
        }
        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void NewCorner(int a)
        {
            Assert.Equal(_spaceShip.Corner, a);
        }
        [Given("космический корабль, угол наклона которого невозможно определить")]
        public void UndefinedCorner()
        {
            _spaceShip.SetCorner(361);
        }
        [Given("мгновенную угловую скорость невозможно определить")]
        public void UndefinedSpeedCorner()
        {
            _spaceShip.SetCornerSpeed(361);
        }
        [Given("невозможно изменить уголд наклона к оси OX космического корабля")]
        public void CantChangeCorner()
        {
            _spaceShip.SetCorner(361);
        }
        [Then(@"возникает ошибка Exception")]
        public void ErrorException()
        {
            Assert.ThrowsAsync<Exception>(() => throw _actualException);
        }
    }
}
