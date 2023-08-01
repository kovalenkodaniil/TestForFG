using UnityEngine;

namespace Infrastructure.Services
{
    public class InputService : IService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        public Vector3 Direction =>
            new Vector3(SimpleInput.GetAxis(Horizontal), 0, SimpleInput.GetAxis(Vertical));
    }
}
