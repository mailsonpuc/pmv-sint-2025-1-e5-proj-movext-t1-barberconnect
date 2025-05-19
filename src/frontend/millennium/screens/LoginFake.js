import React from 'react';
import { View, Button } from 'react-native';

export default function LoginFake({ navigation }) {
  return (
    <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
      <Button title="Home" onPress={() => navigation.navigate('HomeBarbeiro')} />
    </View>
  );
}
