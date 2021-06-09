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
        },
        {
            path: 'update/:id',
            name: 'updateDevice',
            component: () =>
                import ('../views/device/Update.vue')
        },
        {
            path: 'view/:id',
            name: 'viewSensor',
            component: () =>
                import ('../views/device/View.vue')
        }
    ]
}