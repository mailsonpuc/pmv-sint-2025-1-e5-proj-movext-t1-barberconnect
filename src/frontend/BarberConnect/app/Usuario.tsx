import * as React from 'react';
import { StyleSheet, View, Alert } from 'react-native';
import { Button, TextInput } from 'react-native-paper';
import { router } from 'expo-router'; // <- Importa o roteador

const Usuario = () => {
  const [nome, setNome] = React.useState('');
  const [email, setEmail] = React.useState('');
  const [senha, setSenha] = React.useState('');

  const handleOk = async () => {
    try {
      const response = await fetch(
        'https://apibarbearia-eahzdfefbpgwbah5.brazilsouth-01.azurewebsites.net/api/Auth/register',
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            username: nome,
            email: email,
            password: senha,
          }),
        }
      );

      if (response.ok) {
        Alert.alert('Sucesso', 'Usuário registrado com sucesso!', [
          {
            text: 'OK',
            onPress: () => router.replace('/'), // ← redireciona para a Home
          },
        ]);
      } else {
        const error = await response.json();
        Alert.alert('Erro', error.message || 'Não foi possível registrar.');
      }
    } catch (err) {
      console.error('Erro na requisição:', err);
      Alert.alert('Erro', 'Erro de conexão com o servidor.');
    }
  };

  return (
    <View style={styles.container}>
      <TextInput
        label="Nome de usuário"
        value={nome}
        onChangeText={setNome}
        style={styles.input}
        autoCapitalize="none"
      />

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
