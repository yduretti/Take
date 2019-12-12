using Xunit;
using Client;
using Microsoft.AspNet.SignalR.Hubs;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using System.Dynamic;
using System;
using IClientProxy = Microsoft.AspNetCore.SignalR.IClientProxy;
using System.Threading;

namespace Client.Test
{

    public class ChatHubTest
    {
        public interface IClientContract
{
    void RaiseAlert(string message);
}

        [Fact]
        public async Task CHeckIfSendMessageToAllWasVerified()
        {
            var mockClientProxy = new Mock<IClientProxy>();

            var mockClients = new Mock<IHubClients>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            var hub = new Mock<IHubContext<ChatHub>>();
            hub.Setup(x => x.Clients).Returns(() => mockClients.Object);

            await hub.Object.Clients.All.SendCoreAsync("SendMessageToAll", null, new CancellationToken());
            
            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "SendMessageToAll",
                    null,
                    default(CancellationToken)),
                Times.Once);
        }

        [Fact]
        public async Task CHeckIfSendMessageToCallerllWasVerified()
        {
            var mockClientProxy = new Mock<IClientProxy>();

            var mockClients = new Mock<IHubClients>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            var hub = new Mock<IHubContext<ChatHub>>();
            hub.Setup(x => x.Clients).Returns(() => mockClients.Object);

            await hub.Object.Clients.All.SendCoreAsync("SendMessageToCaller", null, new CancellationToken());

            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "SendMessageToCaller",
                    null,
                    default(CancellationToken)),
                Times.Once);
        }

        [Fact]
        public async Task CHeckIfSendMessageToUserWasVerified()
        {
            var mockClientProxy = new Mock<IClientProxy>();

            var mockClients = new Mock<IHubClients>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            var hub = new Mock<IHubContext<ChatHub>>();
            hub.Setup(x => x.Clients).Returns(() => mockClients.Object);

            await hub.Object.Clients.All.SendCoreAsync("SendMessageToUser", null, new CancellationToken());

            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "SendMessageToUser",
                    null,
                    default(CancellationToken)),
                Times.Once);
        }

        [Fact]
        public async Task CHeckIfJoinGroupWasVerified()
        {
            var mockClientProxy = new Mock<IClientProxy>();

            var mockClients = new Mock<IHubClients>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            var hub = new Mock<IHubContext<ChatHub>>();
            hub.Setup(x => x.Clients).Returns(() => mockClients.Object);

            await hub.Object.Clients.All.SendCoreAsync("JoinGroup", null, new CancellationToken());

            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "JoinGroup",
                    null,
                    default(CancellationToken)),
                Times.Once);
        }

        [Fact]
        public async Task CHeckIfSendMessageToGroupWasVerified()
        {
            var mockClientProxy = new Mock<IClientProxy>();

            var mockClients = new Mock<IHubClients>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            var hub = new Mock<IHubContext<ChatHub>>();
            hub.Setup(x => x.Clients).Returns(() => mockClients.Object);

            await hub.Object.Clients.All.SendCoreAsync("SendMessageToGroup", null, new CancellationToken());

            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "SendMessageToGroup",
                    null,
                    default(CancellationToken)),
                Times.Once);
        }
    }
}
