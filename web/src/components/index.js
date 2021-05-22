export const Setup = (vue) => {
    vue.component('arduino-toolbar', () =>
        import ('./toolbar.vue'))
}