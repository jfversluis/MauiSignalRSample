using Microsoft.AspNetCore.SignalR.Client;

namespace MauiSignalRSample;

public partial class MainPage : ContentPage
{
	private readonly HubConnection _connection;

	public MainPage()
	{
		InitializeComponent();

		_connection = new HubConnectionBuilder()
			.WithUrl("http://192.168.1.85:5296/chat")
			.Build();

		_connection.On<string>("MessageReceived", (message) =>
		{
			chatMessages.Text += $"{Environment.NewLine}{message}";
		});

		Task.Run(() =>
		{
			Dispatcher.Dispatch(async () =>
			await _connection.StartAsync());
		});
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await _connection.InvokeCoreAsync("SendMessage", args: new[] { myChatMessage.Text });

		myChatMessage.Text = String.Empty;
	}
}

