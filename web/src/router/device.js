export default {
    path: '/device',
    component: () =>
        import ('../layout/DashboardLayout.vue'),
    children: [{
            path: 'list',
            name: 'devices',
            component: () =>
                import ('../views/device/Index.vue')
        },
        {
            path: 'new',
            name: 'newDevice',
            component: () =>
                import ('../views/device/New.vue')
        }
    ]
}