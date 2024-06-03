using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using MockNetworkUtility.DNS;
using MockNetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.BasicConsole.XUnit.Core.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;
        private readonly IDNS _dns;
        public NetworkServiceTests()
        {
            _dns = A.Fake<IDNS>();

            //SUT -- System Under Test 
            _pingService = new NetworkService(_dns);
        }
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - Go get variables, whatever you need (classes, functions, etc.)

            A.CallTo(() => _dns.SendDNS()).Returns(true); //Mock the DNS.SendDNS() method
         
            //Act - Execute the function you want to test
            var result = _pingService.SendPing();


            //Assert - Is whatever is returned what you were actually expecting
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            //result.Should().Contain("Success", Exactly.Times(1));
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]//Fact that allow you to pass inline variables
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange - Go get variables, whatever you need (classes, functions, etc.)
           
            //Act - Execute the function you want to test
            var result = _pingService.PingTimeout(a, b);


            //Assert - Is whatever is returned what you were actually expecting
            result.Should().Be(expected);
            result.Should().BeGreaterThan(1);
            result.Should().NotBeInRange(-1000, 0);

        }
        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()    
        {
            //Arrange - Go get variables, whatever you need (classes, functions, etc.)

            //Act - Execute the function you want to test
            var result = _pingService.LastPingDate();


            //Assert - Is whatever is returned what you were actually expecting
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }
        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject()    
        {
            //Arrange - Go get variables, whatever you need (classes, functions, etc.)
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1,
            };
            //Act - Execute the function you want to test
            var result = _pingService.GetPingOptions();


            //Assert - WARNING: "Be" careful
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }
        
        [Fact]
        public void NetworkService_MostRecentPings_ReturnsObject()    
        {
            //Arrange - Go get variables, whatever you need (classes, functions, etc.)
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1,
            };
            //Act - Execute the function you want to test
            var result = _pingService.MostRecentPings();


            //Assert - WARNING: "Be" careful
            result.Should().ContainItemsAssignableTo<PingOptions>();
            result.Should().AllBeOfType<PingOptions>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }

    }
}
