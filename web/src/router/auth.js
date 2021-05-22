export default {
    path: '/auth',
    component: () =>
        import ('../layout/BlankLayout.vue'),
    children: [{
            path: '',
            name: 'blankLogin',
            component: () =>
                import ('../views/auth/Login.vue')
        },
        {
            path: 'login',
            name: 'login',
            component: () =>
                import ('../views/auth/Login.vue')
        },
        {
            path: 'register',
            name: 'register',
            component: () =>
                import ('../views/auth/Register.vue')
        }
    ]
}