﻿using Dotnet7SignalRSample.Data;
using Microsoft.AspNetCore.SignalR;

namespace Dotnet7SignalRSample.Hubs;

public class ChatHub : Hub
{
    private readonly ApplicationDbContext _db;
    public ChatHub(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task SendMessageToAll(string user, string message)
    {
        await Clients.All.SendAsync("MessageReceived", user, message);
    }

    public async Task SendMessageToReceiver(string sender, string receiver, string message)
    {
        var userId = _db.Users.FirstOrDefault(u => u.Email.ToLower() == receiver.ToLower()).Id;

        if (!string.IsNullOrEmpty(userId))
        {
            await Clients.User(userId).SendAsync("MessageReceived", sender, message);
        }

    }
}