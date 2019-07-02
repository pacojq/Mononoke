using Mononoke.Physics;

namespace Mononoke.Systems
{
	public class CollisionSystem : Core.System<RenderingSystem.Filter>
	{

		public struct Filter
		{
			public ICollider Collider;
		}

		
		protected override void UpdateEntity(RenderingSystem.Filter entity)
		{
			throw new System.NotImplementedException();
		}
	}
}