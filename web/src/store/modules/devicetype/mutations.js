import { SET_DEVICE_TYPES } from './mutations.type'
const mutations = {
    [SET_DEVICE_TYPES](state, payload) {
        state.deviceTypes = payload.deviceTypes;
    }
}

export default mutations;