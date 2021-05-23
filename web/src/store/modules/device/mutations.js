import { SET_DEVICES, SET_DEVICE } from './mutations.type'

const mutations = {
    [SET_DEVICES](state, payload) {
        state.devices = payload.devices;
    },
    [SET_DEVICE](state, payload) {
        state.device = payload.device;
    }
}

export default mutations;