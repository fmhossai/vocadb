using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VocaDb.Model.Domain.PVs;

namespace VocaDb.Model.DataContracts.Users
{
	/// <summary>
	/// Contains no sensitive information.
	/// </summary>
	public sealed record SanitizedUserWithPermissionsContract
	{
		public int Id { get; init; }
		public string Name { get; init; } = string.Empty;
		public bool Active { get; init; }
		public Guid[] EffectivePermissions { get; init; } = Array.Empty<Guid>();
		public int UnreadMessagesCount { get; init; }
		public bool VerifiedArtist { get; init; }
		public ArtistForUserContract[] OwnedArtistEntries { get; init; } = Array.Empty<ArtistForUserContract>();

		[JsonConverter(typeof(StringEnumConverter))]
		public PVService PreferredVideoService { get; init; }

		public SanitizedUserWithPermissionsContract() { }

		public SanitizedUserWithPermissionsContract(ServerOnlyUserWithPermissionsContract user)
		{
			Id = user.Id;
			Name = user.Name;
			Active = user.Active;
			EffectivePermissions = user.EffectivePermissions.Select(p => p.Id).ToArray();
			UnreadMessagesCount = user.UnreadMessagesCount;
			VerifiedArtist = user.VerifiedArtist;
			OwnedArtistEntries = user.OwnedArtistEntries;
			PreferredVideoService = user.PreferredVideoService;
		}
	}
}
