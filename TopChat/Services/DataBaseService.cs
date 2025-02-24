using System;
using System.Text;
using TopChat.Models.Entities;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class DataBaseService : IDataBaseService
	{
		private IDataConverterService _converterService;

		private ADatabaseConnection _connection;

		public DataBaseService(IDataConverterService converterService, ADatabaseConnection connection)
		{
			this._converterService = converterService;
			this._connection = connection;
		}
		public void AddMessage(byte[] bytesData)
		{
			IUserServes userServes = new UserService(this._connection);

			Message message = new Message();

			string receivedText = Encoding.UTF8.GetString(bytesData);

			string[] dataSplitText = receivedText.Split('|');

			if (dataSplitText.Length <= 2)
			{
				message.DateTime = Convert.ToDateTime(dataSplitText[0]);

				message.MediaData = new Media() { Text = dataSplitText[1] };

			}
			else
			{
				message.DateTime = Convert.ToDateTime(dataSplitText[0]);

				message.MediaData = new Media() { Text = dataSplitText[1] };

				message.Sender = userServes.GetUser(dataSplitText[2]);

				message.Recipient = userServes.GetUser(dataSplitText[3]);
			}

			this._connection.Messages.Add(message);

		}
	}
}
