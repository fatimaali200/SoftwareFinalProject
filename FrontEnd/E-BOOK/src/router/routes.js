const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('src/pages/Home.vue') },
      { path: '/payment/:id', component: () => import('src/pages/Payment.vue') },
      { path: '/new', component: () => import('src/pages/NewBook.vue') },
      { path: '/edit', component: () => import('src/pages/Edit.vue') },
      { path: '/admin', component: () => import('src/pages/Admin.vue') },
      { path: '/bought', component: () => import('src/pages/boughtBooks.vue') },
      { path: '/details/:id', component: () => import('src/pages/Details.vue') }
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
