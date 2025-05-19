import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';

import Welcome from './screens/Welcome';
import Login from './screens/LoginFake';
import Register from './screens/Register';
import ServiceCategories from './screens/ServiceCategories';
import Home from './screens/Home';
import HomeBarbeiro from './screens/HomeBarbeiro';
import ServicosPopulares from './screens/ServicosPopulares';
import OutrosServicos from './screens/OutrosServicos';
import ServicosMillennium from './screens/ServicosMillennium';
import CombosMillennium from './screens/CombosMillennium';
import Agendamento from './screens/Agendamento';
import Historico from './screens/Historico';
import Proximos from './screens/Proximos';
import MinhaConta from './screens/MinhaConta';
import AgendaBarbeiro from './screens/AgendaBarbeiro';

const Stack = createNativeStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
        <Stack.Navigator screenOptions={{ headerShown: false }} initialRouteName="Welcome">
        <Stack.Screen name="Welcome" component={Welcome} />
        <Stack.Screen name="Login" component={Login} />
        <Stack.Screen name="Register" component={Register} />
        <Stack.Screen name="ServiceCategories" component={ServiceCategories} />
        <Stack.Screen name="Home" component={Home} />
        <Stack.Screen name="ServicosPopulares" component={ServicosPopulares} />
        <Stack.Screen name="OutrosServicos" component={OutrosServicos} />
        <Stack.Screen name="ServicosMillennium" component={ServicosMillennium} />
        <Stack.Screen name="CombosMillennium" component={CombosMillennium} />
        <Stack.Screen name="Agendamento" component={Agendamento} />
        <Stack.Screen name="Historico" component={Historico} />
        <Stack.Screen name="Proximos" component={Proximos} />
        <Stack.Screen name="MinhaConta" component={MinhaConta} />
        <Stack.Screen name="HomeBarbeiro" component={HomeBarbeiro} />
        <Stack.Screen name="AgendaBarbeiro" component={AgendaBarbeiro} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}
