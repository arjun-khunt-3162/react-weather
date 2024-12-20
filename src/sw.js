/// <reference lib="webworker" />
import { cleanupOutdatedCaches, createHandlerBoundToURL, precacheAndRoute } from 'workbox-precaching'
import { NavigationRoute, registerRoute } from 'workbox-routing'
import { initializeApp } from "firebase/app";
import { getMessaging } from "firebase/messaging/sw";

self.addEventListener('message', (event) => {
  if (event.data && event.data.type === 'SKIP_WAITING')
    self.skipWaiting()
})

// self.__WB_MANIFEST is the default injection point
precacheAndRoute(self.__WB_MANIFEST)

// clean old assets
cleanupOutdatedCaches()

/** @type {RegExp[] | undefined} */
let allowlist
// in dev mode, we disable precaching to avoid caching issues
if (import.meta.env.DEV)
  allowlist = [/^\/$/]

// to allow work offline
registerRoute(new NavigationRoute(
  createHandlerBoundToURL('index.html'),
  { allowlist },
))

const firebaseApp = initializeApp({
  apiKey: 'AIzaSyDkoifEE8F3G-NwcFjHmW_tazmHP21rtIE',
  authDomain: 'react-vite-pwa-5882e.firebaseapp.com',
  projectId: 'react-vite-pwa-5882e',
  storageBucket: 'react-vite-pwa-5882e.firebasestorage.app',
  messagingSenderId: '107589266177',
  appId: '1:107589266177:web:77884455c1503bf3f0c900',
  // measurementId: ""
});

// Retrieve an instance of Firebase Messaging so that it can handle background
// messages.
const messaging = getMessaging(firebaseApp);
