import { SET_AVAILABLE_PINS } from './mutations.type'

const mutations = {
    [SET_AVAILABLE_PINS](state, payload) {
        state.availablePins = payload.pins
    }
}

export default mutations;