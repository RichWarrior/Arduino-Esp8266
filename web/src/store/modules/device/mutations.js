import { SET_DEVICES } from './mutations.type'

const mutations = {
    [SET_DEVICES](state, payload) {
        state.devices = payload.devices;
    }
}

export default mutations;