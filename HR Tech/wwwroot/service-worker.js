// Service Worker installation
self.addEventListener('install', function (event) {
    event.waitUntil(
        caches.open('your-cache-name').then(function (cache) {
            return cache.addAll([
                // Add URLs of assets to cache
                '/css/styles.css',
                '/js/main.js',
                '/offline.html' // Offline fallback page
            ]);
        })
    );
});

// Service Worker activation
self.addEventListener('activate', function (event) {
    event.waitUntil(
        caches.keys().then(function (cacheNames) {
            return Promise.all(
                cacheNames.filter(function (cacheName) {
                    // Delete old caches if needed
                    return cacheName !== 'your-cache-name';
                }).map(function (cacheName) {
                    return caches.delete(cacheName);
                })
            );
        })
    );
});

// Service Worker fetch event
self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request).then(function (response) {
            // Cache hit - return response
            if (response) {
                return response;
            }

            // Clone the request
            var fetchRequest = event.request.clone();

            return fetch(fetchRequest).then(function (response) {
                // Check if we received a valid response
                if (!response || response.status !== 200 || response.type !== 'basic') {
                    return response;
                }

                // Clone the response
                var responseToCache = response.clone();

                // Cache the fetched response
                caches.open('your-cache-name').then(function (cache) {
                    cache.put(event.request, responseToCache);
                });

                return response;
            });
        }).catch(function () {
            // Return offline fallback page if no cache match and no network
            return caches.match('/offline.html');
        })
    );
});
