﻿using System.ComponentModel.DataAnnotations;

namespace eSportSchool.Facade
{
    public abstract class UniqueView
    {
        [Required] public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
