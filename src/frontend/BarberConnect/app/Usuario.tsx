import * as React from 'react';
import { StyleSheet, View } from 'react-native';
import { Button, TextInput } from 'react-native-paper';

const Usuario = () => {
  const [email, setEmail] = React.useState('');
  const [senha, setSenha] = React.useState('');

  const handleOk = () => {
    // Aqui você pode lidar com o login
    console.log('Email:', email);
    console.log('Senha:', senha);
  };

  return (
    <View style={styles.container}>
      <TextInput
        label="Email"
        value={email}
        onChangeText={setEmail}
        style={styles.input}
        keyboardType="email-address"
        autoCapitalize="none"
      />
      <TextInput
        label="Senha"
        value={senha}
        onChangeText={setSenha}
        secureTextEntry
        style={styles.input}
      />
      <Button mode="contained" onPress={handleOk}>
        OK
      </Button>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 16,
    justifyContent: 'center',
  },
  input: {
    marginBottom: 16,
  },
});

export default Usuario;
