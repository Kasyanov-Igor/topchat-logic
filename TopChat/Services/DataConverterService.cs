using System;
using System.IO;
using System.Text;
using TopChat.Services.Interfaces;
using System.Collections.Generic;
using TopChat.Models.Entities;
using TopChat.Models.Domains;

namespace TopChat.Services
{
	public class DataConverterService : IDataConverterService
	{
		private ADatabaseConnection _connection = new SqliteConnection();

		public NetworkData ConvertToNetworkData(Message fromEntity)
		{
			NetworkData result = new NetworkData();

			result.DestinationIP = "127.0.0.1"; //message.Sender.GetIpFromService()
			result.DestinationPort = 5000;

			if (fromEntity.MediaData.Text != "" && fromEntity.MediaData.PathToFile == null)
			{
				result.Data = new byte[1024];
				string dataText = $"{fromEntity.MediaData.Text}|{fromEntity.Sender.Login}|{fromEntity.Recipient.Login}|{fromEntity.DateTime}";
				result.Data = Encoding.UTF8.GetBytes(dataText);

				return result;
			}
			else
			{
				result.Data = File.ReadAllBytes(fromEntity.MediaData.PathToFile);

				byte[] fileNameBytes = System.Text.Encoding.UTF8.GetBytes(Path.GetFileName(fromEntity.MediaData.PathToFile));
			}
			return result;
		}

		public List<Message> ConvertFromNetworkData(NetworkData result)
		{
			List<Message> messages = new List<Message>();

			byte[] received = new byte[1024];

		
				byte[] receivedBytes = result.Data;
				string receivedText = Encoding.UTF8.GetString(receivedBytes);

				string[] splitText = receivedText.Split('|');

				if (splitText[0] == "read")
				{
					foreach (var mass in this._connection.Messages)
					{
						if (mass.Sender.Login == splitText[2] && mass.Recipient.Password == splitText[3])
						{
							messages.Add(mass);
						}
					}
				}
	
			return messages;
		}
	}
}
