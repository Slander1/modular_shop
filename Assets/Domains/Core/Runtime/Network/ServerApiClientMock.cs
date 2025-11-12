using System;
using System.Threading;
using Core.Utility;
using Cysharp.Threading.Tasks;

namespace Core.Network
{
    public sealed class ServerApiClientMock : SingletonBase<ServerApiClientMock>
    {
        public event Action PurchaseStart;
        public event Action PurchaseSuccess;
        public event Action PurchaseFailed;
        
        public async UniTask<bool> TryPurchaseBundle(string bundleId, CancellationToken cancellationToken)
        {
            PurchaseStart?.Invoke();

            try
            {
                await UniTask.Delay(
                    TimeSpan.FromSeconds(3), 
                    cancellationToken: cancellationToken);

                PurchaseSuccess?.Invoke();
                return true;
            }
            catch (OperationCanceledException)
            {
                PurchaseFailed?.Invoke();
                return false;
            }
        }
    }
}