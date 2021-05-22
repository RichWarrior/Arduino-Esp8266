import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import { Setup as SetupComponent } from './components'
import { Setup as SetupPlugins } from './plugins'

SetupComponent(Vue);
SetupPlugins(Vue)


Vue.config.productionTip = false

new Vue({
    router,
    store,
    vuetify,
    render: h => h(App)
}).$mount('#app')