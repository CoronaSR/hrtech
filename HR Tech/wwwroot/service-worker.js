(function () {
    //Insert Your Service Worker In place of this one!
    // Service Worker installation
    self.addEventListener('install', function (event) {
        event.waitUntil(
            caches.open('v1').then(function (cache) {
                return cache.addAll([
                    // Add URLs of assets to cache
                    '/css/site.css',
                    '/js/site.js',
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
                        return cacheName !== 'v1';
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

                    // Check if the request is for an asset file
                    var url = new URL(event.request.url);
                    if (url.pathname.startsWith('/assets/')) {
                        // Clone the response
                        var responseToCache = response.clone();

                        // Cache the fetched response
                        caches.open('v1').then(function (cache) {
                            cache.put(event.request, responseToCache);
                        });
                    }

                    return response;
                });
            }).catch(function () {
                // Return offline fallback page if no cache match and no network
                return caches.match('/offline.html');
            })
        );
    });

    // Update 'version' if you need to refresh the cache
    var version = '{version}';
    var offlineUrl = "{offlineRoute}";
    var routes = "{routes}";
    var routesToIgnore = "{ignoreRoutes}";
});
