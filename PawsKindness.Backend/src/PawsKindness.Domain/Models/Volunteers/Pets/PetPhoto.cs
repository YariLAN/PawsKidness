﻿namespace PawsKindness.Domain.Models.Volunteers.Pets
{
    public class PetPhoto
    {
        public Guid Id { get; private set; }

        public string Path { get; private set; } = string.Empty;

        public bool IsMain { get; private set; }
    }
}
