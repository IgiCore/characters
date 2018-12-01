using System.Data.Entity;
using IgiCore.Characters.Server.Models;
using NFive.SDK.Core.Models.Player;
using NFive.SDK.Server.Storage;

namespace IgiCore.Characters.Server.Storage
{
	public class StorageContext : EFContext<StorageContext>
	{
		public DbSet<Character> Characters { get; set; }
	}
}
