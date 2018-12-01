using JetBrains.Annotations;
using NFive.SDK.Server.Migrations;
using IgiCore.Characters.Server.Storage;

namespace IgiCore.Characters.Server.Migrations
{
	[UsedImplicitly]
	public sealed class Configuration : MigrationConfiguration<StorageContext> { }
}
