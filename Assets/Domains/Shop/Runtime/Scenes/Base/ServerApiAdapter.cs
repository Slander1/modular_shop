using System;
using System.Threading;
using Core.Network;
using Cysharp.Threading.Tasks;
using Shop.Bundle.Data;

namespace Shop.Scenes.Base
{
    public class ServerApiAdapter : IDisposable
    {
        private readonly ServerApiClientMock _serverApiClient = ServerApiClientMock.Instance;

        private CancellationTokenSource _cancellationToken;

        public async UniTask InitializePurchase(BundleData bundleData)
        {
            DisposeToken();
            _cancellationToken = new CancellationTokenSource();
            
            _serverApiClient.PurchaseStart += OnPurchaseStart;
            await _serverApiClient.TryPurchaseBundle(bundleData.ToString(), _cancellationToken.Token);
         }
        
        private void OnPurchaseStart()
        {
            _serverApiClient.PurchaseSuccess += OnPurchaseSuccess;
            _serverApiClient.PurchaseFailed += OnPurchaseFailed;
        }

        private void OnPurchaseSuccess()
        {
            UnsubscribeFromServerEvents();
        }
        
        private void OnPurchaseFailed()
        {
            UnsubscribeFromServerEvents();
        }

        private void UnsubscribeFromServerEvents()
        {
            _serverApiClient.PurchaseStart -= OnPurchaseStart;
            _serverApiClient.PurchaseSuccess -= OnPurchaseSuccess;
            _serverApiClient.PurchaseFailed -= OnPurchaseFailed;
        }
        
        private void DisposeToken()
        {
            if (_cancellationToken == null) return;
            
            _cancellationToken?.Dispose();
            _cancellationToken = null;
        }
        
        public void Dispose()
        {
            DisposeToken();
        }
    }
}