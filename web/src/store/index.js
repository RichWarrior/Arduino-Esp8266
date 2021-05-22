import Vue from 'vue'
import Vuex from 'vuex'

import base from './modules/base'
import auth from './modules/auth'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        base,
        auth
    }
})