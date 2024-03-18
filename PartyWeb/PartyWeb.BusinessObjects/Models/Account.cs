using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public byte Role { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeletedTime { get; set; }

    public string? Infomation { get; set; }

    public string? Address { get; set; }

    public DateTime? Dob { get; set; }

    public string? Fullname { get; set; }

    public virtual ICollection<Decor> Decors { get; set; } = new List<Decor>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PartyHost> PartyHosts { get; set; } = new List<PartyHost>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
