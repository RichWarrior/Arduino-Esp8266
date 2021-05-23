import Vue from 'vue'
import Vuex from 'vuex'

import base from './modules/base'
import auth from './modules/auth'
import devicetype from './modules/devicetype'
import device from './modules/device'
import sensor from './modules/sensor'
import pin from './modules/pin'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        base,
        auth,
        devicetype,
        device,
        sensor,
        pin
    }
})