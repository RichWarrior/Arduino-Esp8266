export default {
    path: '/dashboard',
    component: () =>
        import ('../layout/DashboardLayout.vue'),
    children: [{
        path: '',
        name: 'dashboard',
        component: () =>
            import ('../views/dashboard/Index.vue')
    }]
}