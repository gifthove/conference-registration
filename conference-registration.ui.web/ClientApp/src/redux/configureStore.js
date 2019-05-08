import { createStore, applyMiddleware, compose } from "redux";
import rootReducer from "./reducers/index";
import reduxImmutableStateInvariant from "redux-immutable-state-invariant";
import thunk from "redux-thunk";

export default function configureStore(initialStore) {
  const composeEnhancers =
    window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose; //adds support for Redux dev tools
  return createStore(
    rootReducer,
    initialStore,
    composeEnhancers(applyMiddleware(thunk, reduxImmutableStateInvariant()))
  );
}
