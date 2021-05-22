export const Setup = (vue) => {
    vue.component('arduino-toolbar', () =>
        import ('./Toolbar.vue'))

    vue.component('arduino-sidebar', () =>
        import ('./Sidebar.vue'))
}