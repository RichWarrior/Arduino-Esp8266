import { SET_DEVICE_DETAILS } from './mutations.type'

const mutations = {
    [SET_DEVICE_DETAILS](state, payload) {
        state.deviceDetails = payload.deviceSensors;
    }
}

export default mutations;