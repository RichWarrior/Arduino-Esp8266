import { SET_SENSORS } from './mutations.type'

const mutations = {
    [SET_SENSORS](state, payload) {
        state.sensors = payload.sensors;
    }
}

export default mutations;