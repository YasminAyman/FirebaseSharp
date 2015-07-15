﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FirebaseSharp.Portable;
using FirebaseSharp.Portable.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirebaseSharp.Tests
{
    [TestClass]
    public class ArrayTest
    {
        [TestMethod]
        public void NestArrayStructure()
        {
            string json =
                "{\"structures\":{\"HLSA0JTk_CYZ5uwDDMMikq2pcKsV7D7gp5UuRUaPRTDlBZM6F_dczQ\":{\"name\":\"Home_CN\",\"country_code\":\"CN\",\"time_zone\":\"Asia/Chongqing\",\"away\":\"away\",\"thermostats\":[\"d9OLyd8P_iClYVC9bOYXemVq2RZu77lD\",\"d9OLyd8P_iAcg6TkKYp3N2Vq2RZu77lD\",\"d9OLyd8P_iADyClc5F8JGmVq2RZu77lD\"],\"structure_id\":\"HLSA0JTk_CYZ5uwDDMMikq2pcKsV7D7gp5UuRUaPRTDlBZM6F_dczQ\"},\"FxaEqRi1IyrfVI657-saheQIvC8SoIhFETvbNtDi5R4vrUCOFPI3fA\":{\"smoke_co_alarms\":[\"TSQUTH_cGzcBhmByXCN-jmVq2RZu77lD\",\"TSQUTH_cGzePdYNnuPuDBWVq2RZu77lD\"],\"name\":\"Home1\",\"country_code\":\"US\",\"time_zone\":\"America/New_York\",\"away\":\"home\",\"thermostats\":[\"d9OLyd8P_iCYt1QycZtlFWVq2RZu77lD\"],\"structure_id\":\"FxaEqRi1IyrfVI657-saheQIvC8SoIhFETvbNtDi5R4vrUCOFPI3fA\"}},\"metadata\":{\"access_token\":\"c.XaxLPE6bDAznivRxdpNYGNmYZDwC1678GUEKaRb7MJJf00aMb2I22XMaUWA6N6McfRZNlU3zy2Hu7Jl1shjhrloQN0LhvfSbrlV7QbxUkV4Qcnn89Y2hQPjVIjGsmGp2B2gMe12GyO9AK66Z\",\"client_version\":6}}";

            IFirebaseResponseMessage response = A.Fake<IFirebaseResponseMessage>();
            A.CallTo(() => response.ReadAsStringAsync()).Returns(Task.Run(() => json));

            IFirebaseHttpClient mockClient = A.Fake<IFirebaseHttpClient>();
            A.CallTo(() => mockClient.SendAsync(A<HttpRequestMessage>._, A<HttpCompletionOption>._)).Returns(response);
            A.CallTo(() => mockClient.BaseAddress).Returns(new Uri("http://example.com"));

            Request r= new Request(mockClient, null);
            var postResult = r.Post("/nest", json).Result;
            Console.WriteLine(postResult);

            Assert.AreEqual(json, postResult);
        }
    }
}
